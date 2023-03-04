using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TwoDMinecraft.Core
{
    public class BlockBreaking : MonoBehaviour
    {
        private float _startTime;
        public static bool IsBreaking;
        private Vector3Int _lastPosition;
        private bool _once;
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (_once)
                {
                    _startTime = Time.time;
                    _once = false;
                }
                foreach (Block block in Blocks.BlockList)
                {
                    if (block.Tile == Core.Tilemap.GetTile<Tile>(Core.CurrentCell))
                    {
                        if (block.BreakTime != -1) IsBreaking = true;
                        //Debug.Log($"ST: {_startTime}, BT: {block.breakTime}, T: {Time.time}, PT: {_startTime + block.breakTime}");
                        if (_lastPosition != Core.CurrentCell) _once = true;
                        if (Time.time >= _startTime + block.BreakTime)
                        {
                            Core.Tilemap.SetTile(Core.CurrentCell, null);
                            _once = true;
                            break;
                        }
                    }
                }
                _lastPosition = Core.CurrentCell;
            }
            else
            {
                IsBreaking = false;
                _once = true;
            }
        }
    }
}
