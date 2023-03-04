using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace TwoDMinecraft.Editor
{
    public class SortBuildScene : EditorWindow
    {
        const string menuPath = "Tools/2DMinecraft/";
        [MenuItem(menuPath + "SortBuildScenes")]
        static void Main()
        {
            var scenes = EditorBuildSettings.scenes;
            var list = new List<EditorBuildSettingsScene>(scenes);
            var sortedScenes = list.OrderBy((e) =>
            {
                return e.path;
            }).ToArray();
            EditorBuildSettings.scenes = sortedScenes;
        }
    }
}