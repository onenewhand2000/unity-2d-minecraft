using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    [System.Serializable]
    public class Chunk 
    {
        public List<WorldBlock> List = new List<WorldBlock>();
    }
}
