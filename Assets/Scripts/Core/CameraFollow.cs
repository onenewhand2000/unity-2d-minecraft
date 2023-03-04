using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    public class CameraFollow : MonoBehaviour
    {
        private GameObject _objectToFollow;
        private Vector2 _mousePositionLimit = new Vector2(0.5f, 0.5f);
        private float _t;
        private IEnumerator Start()
        {
            yield return new WaitForCoreStart();
            _objectToFollow = GameObject.Find("Player");
        }
        private void Update()
        {
            if (!Core.IsStarted) return;
            if (_objectToFollow == null) { _objectToFollow = GameObject.Find("Player"); return; }
            _t = 0.05f;
            Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(
                _objectToFollow.transform.position.x + mousePosition.x,
                _objectToFollow.transform.position.y + mousePosition.y,
                -10);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition, _t);
            //UnityEngine.Debug.DrawLine(mousePosition - new Vector3(1, 1, 0), mousePosition + new Vector3(1, 1, 0));
            //UnityEngine.Debug.DrawLine(mousePosition - new Vector3(1, -1, 0), mousePosition + new Vector3(1, -1, 0));
            //_t = 0;
        }
    }
}
