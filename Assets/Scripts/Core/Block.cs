using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TwoDMinecraft.Core
{
    public class Block
    {
        private string _oldName;
        private Tile _oldTile;
        private float _oldBreakTime;

        public string Name = null;
        public Tile Tile = null;
        public float BreakTime = -2;

        public Block()
        {
            if (Name != null) _oldName = Name;
            if (Tile != null) _oldTile = Tile;
            if (BreakTime != -2) _oldBreakTime = BreakTime;
        }

        public Block SetName(string name)
        {
            Name = name;
            return this;
        }

        public Block SetTile(Tile tile)
        {
            Tile = tile;
            return this;
        }

        public Block SetTile(string tilePath)
        {
            return SetTile(Resources.Load<Tile>(tilePath));
        }

        public Block SetTile(bool isNull)
        {
            if (isNull) Tile = null;
            return this;
        }

        public Block SetBreakTime(float time)
        {
            BreakTime = time / 1000;
            return this;
        }

        public Block Apply()
        {
            Blocks.BlockList.Add(this);
            Blocks.BlockDictionary[Name] = this;
            return this;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {{ Name: {Name}, Tile: {Tile}, Break Time: {BreakTime} }}";
        }
    }
}
