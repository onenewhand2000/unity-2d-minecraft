using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    public class InputManager : MonoBehaviour
    {
        public static Vector2 Axes = Vector2.zero;

        private void Update()
        {
            Axes = Vector2.zero;
            if (Input.GetKey(KeyCode.A)) { Axes.x = -1f; }
            if (Input.GetKey(KeyCode.D)) { Axes.x = 1f; }
            if (Input.GetKey(KeyCode.W)) { Axes.y = 1f; }
            if (Input.GetKey(KeyCode.S)) { Axes.y = -1f; }
        }
    }
}
