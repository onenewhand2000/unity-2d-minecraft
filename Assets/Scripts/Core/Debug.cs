using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft
{
    public class Debug
    {
        public static void Log(object message)
        {
            Log(message, false);
        }

        public static void Log(object message, bool showInBuild)
        {
            if (showInBuild)
            {
                UnityEngine.Debug.Log(message);
            }
            else
            {
#if UNITY_EDITOR
                UnityEngine.Debug.Log(message);
#endif
            };
        }
    }
}
