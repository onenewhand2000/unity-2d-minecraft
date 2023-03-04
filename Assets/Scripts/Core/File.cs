using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    public class File
    {
        public static void Write(string directory, string fileName, string contents)
        {
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, fileName);
            if (!System.IO.File.Exists(path)) System.IO.File.Create(path).Close();
            System.IO.File.WriteAllText(path, contents);
        }

        public static string Read(string filePath)
        {
            if (System.IO.File.Exists(filePath)) return System.IO.File.ReadAllText(filePath);
            return null;
        }
    }
}
