using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    [System.Serializable]
    public class WorldBlock
    {
        [Newtonsoft.Json.JsonIgnore] public Block Block;
        public string BlockName;
        public SerializableVector3Int Position;

        public WorldBlock SetBlock(Block block)
        {
            Block = block;
            BlockName = block.Name;
            return this;
        }

        public WorldBlock SetPosition(SerializableVector3Int position)
        {
            Position = position;
            return this;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {{ Block: {Block}, Position: {Position} }}";
        }
    }
}
