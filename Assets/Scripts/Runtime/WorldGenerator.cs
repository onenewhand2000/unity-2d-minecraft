using System.Collections;
using System.Collections.Generic;
using TwoDMinecraft.Core;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TwoDMinecraft
{
    public class WorldGenerator : MonoBehaviour
    {
        public static WorldGenerator Instance;
        public static int ChunkSize = 16;
        private float noiseFreq = 0.069f;
        private int seed;
        private bool generateCave = true;
        private int worldOffset;
        private Chunk CurrentChunk = new Chunk();
        private int _currentChunkX;
        private bool tmpBool = false;

        private void Awake()
        {
            Instance = this;
        }

        private IEnumerator Start()
        {
            //GenerateNoise();
            //gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(noiseTexture, new Rect(0.0f, 0.0f, worldSize, worldSize), new Vector2(0.5f, 0.5f));
            yield return new WaitForCoreStart();
            Core.Core.Tilemap.ClearAllTiles();
            Core.Core.Chunks = Json.ReadSave(File.Read(System.IO.Path.Join(Application.dataPath, "Saves", "save.dat")));
            yield return new WaitForSeconds(1f);
            tmpBool = true;
            //GenerateMap(-ChunkSize);
            //GenerateMap(0);
            //GenerateMap(ChunkSize);
        }

        private void Update()
        {
            if (!Core.Core.IsStarted) return;
            worldOffset = Core.Core.PlayerXPosition;
            UnityEngine.Debug.DrawLine(new Vector3(Core.Core.PlayerXPosition, -100, 0), new Vector3(Core.Core.PlayerXPosition, 100, 0), Color.white);
            UnityEngine.Debug.DrawLine(new Vector3(worldOffset - ChunkSize, -100, 0), new Vector3(worldOffset - ChunkSize, 100, 0), Color.red);
            UnityEngine.Debug.DrawLine(new Vector3(worldOffset + ChunkSize, -100, 0), new Vector3(worldOffset + ChunkSize, 100, 0), Color.red);
            if (tmpBool)
            {
                UpdateChunks();
            }
        }

        private void GenerateMap(int offset)
        {
            offset -= ChunkSize / 2;
            _currentChunkX = (int)Core.Core.RoundToTheNearestMultiple(worldOffset, ChunkSize) + ChunkSize / 2 + offset;
            CurrentChunk.List.Clear();
            for (int x = 0; x < ChunkSize; x++)
            {
                float height = Mathf.PerlinNoise((x + seed + worldOffset + offset) * noiseFreq, seed * noiseFreq) * 10f + 50f;
                for (int y = 0; y < height; y++)
                {
                    float v = Mathf.PerlinNoise((x + seed + worldOffset + offset) * noiseFreq, (y - seed) * noiseFreq);
                    string block;
                    if (y < height - 5)
                    {
                        block = "Stone";
                    }
                    else if (y < height - 1)
                    {
                        block = "Dirt";
                    }
                    else
                    {
                        block = "Grass";
                    }
                    if (generateCave)
                    {
                        if (v > 0.25f)
                        {
                            PlaceTile(block, x + worldOffset + offset, y);
                            #region Generate Tile (Game Object)
                            //GameObject newTile = new GameObject("tile");
                            //SpriteRenderer spriteRenderer = newTile.AddComponent<SpriteRenderer>();
                            //spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Logo");
                            //newTile.transform.position = new Vector2(x, y);
                            #endregion
                        }
                    }
                    else
                    {
                        PlaceTile(block, x + worldOffset + offset, y);
                    }
                }
            }
            Core.Core.Chunks[_currentChunkX] = CurrentChunk;
        }

        private void PlaceTile(string blockName, int x, int y)
        {
            Block block = Blocks.BlockDictionary[blockName];
            Vector3Int position = new Vector3Int(x, y);
            CurrentChunk.List.Add(new WorldBlock().SetBlock(block).SetPosition(position));
            Core.Core.Tilemap.SetTile(position, block.Tile);
        }

        public static void UpdateChunks()
        {
            //if (Core.Core.Chunks[(int)Core.Core.RoundToTheNearestMultiple(Core.Core.Player.transform.position.x, 16)] != null)
            AP.DebugVariableDisplayer.DebugVariableDisplayer.ShowVariable("A", Core.Core.Chunks.TryGetValue(Core.Core.PlayerXPosition, out Chunk value1));
            if (Core.Core.Chunks.TryGetValue(Core.Core.PlayerXPosition, out Chunk value))
            {
                AP.DebugVariableDisplayer.DebugVariableDisplayer.ShowVariable("State", "Load");
                Instance.CurrentChunk.List.Clear();
                var a = 0;
                foreach (var block in value.List)
                {
                    if (Core.Core.Tilemap.GetTile(block.Position) != null)
                    {
                        a++;
                    }
                    if (a < 2) Instance.PlaceTile(block.Block.Name, block.Position.x, block.Position.y);
                }
            }
            else
            {
                AP.DebugVariableDisplayer.DebugVariableDisplayer.ShowVariable("State", "Generate");
                Debug.Log($"Generated, {Core.Core.PlayerXPosition}");
                WorldGenerator.Instance.GenerateMap(0);
                File.Write(System.IO.Path.Join(Application.dataPath, "Saves"), "save.dat", Json.GenerateSave());
            }
        }
    }
}