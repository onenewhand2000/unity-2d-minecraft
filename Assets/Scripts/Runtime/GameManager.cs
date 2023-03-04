using System.Collections;
using System.Collections.Generic;
using TwoDMinecraft.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwoDMinecraft
{
    public class GameManager : MonoBehaviour
    {
        IEnumerator Start()
        {
            registerBlocks();
            yield break;
        }

        private void Update()
        {
            if (!Core.Core.IsStarted) return;
            Core.Core.PlayerXPosition = (int)Core.Core.RoundToTheNearestMultiple(Core.Core.Player.transform.position.x, WorldGenerator.ChunkSize);
            AP.DebugVariableDisplayer.DebugVariableDisplayer.ShowVariable("Player X Position", Core.Core.PlayerXPosition);
        }

        private void registerBlocks()
        {
            new Block().SetName("Air").SetTile(isNull: true).SetBreakTime(-1000).Apply();
            new Block().SetName("Dirt").SetTile("Tiles/Dirt").SetBreakTime(250).Apply();
            new Block().SetName("Grass").SetTile("Tiles/Grass").SetBreakTime(250).Apply();
            new Block().SetName("Stone").SetTile("Tiles/Stone").SetBreakTime(1000).Apply();
            foreach (var block in Blocks.BlockList)
            {
                Debug.Log(block);
            }
        }
    }
}