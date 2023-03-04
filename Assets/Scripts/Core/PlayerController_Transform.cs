using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    public class PlayerController_Transform : MonoBehaviour
    {
        private float _speed = 10f;
        private void Start()
        {
            
        }

        private void Update()
        {
            gameObject.transform.Translate(new Vector3( Time.deltaTime *_speed* InputManager.Axes.x, Time.deltaTime*_speed*InputManager.Axes.y  , 0));
        }
    }
}
