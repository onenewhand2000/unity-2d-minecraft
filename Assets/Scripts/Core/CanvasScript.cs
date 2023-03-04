using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    public class CanvasScript : MonoBehaviour
    {
        private Canvas _canvas;
        private IEnumerator Start()
        {
            _canvas = gameObject.GetComponent<Canvas>();
            yield break;
        }

        private void Update()
        {

        }
    }
}
