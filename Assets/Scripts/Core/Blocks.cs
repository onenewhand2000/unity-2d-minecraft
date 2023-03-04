using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    public class Blocks : MonoBehaviour
    {
        public static List<Block> BlockList = new List<Block>();
        public static Dictionary<string, Block> BlockDictionary = new Dictionary<string, Block>();
    }
}
