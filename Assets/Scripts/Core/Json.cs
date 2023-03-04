using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    public class Json
    {
        public static string GenerateSave()
        {
            return JsonConvert.SerializeObject(Core.Chunks);
        }
        public static Dictionary<int, Chunk> ReadSave(string contents)
        {
            var content = JsonConvert.DeserializeObject<Dictionary<int, Chunk>>(contents);
            foreach (var chunk in content.Values) {
                foreach (var worldBlock in chunk.List) { 
                    worldBlock.Block = Blocks.BlockDictionary[worldBlock.BlockName];
                }
            }
            return content;
        }
    }
}
