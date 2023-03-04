using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    public class Outline : MonoBehaviour
    {
        private GameObject _outline;
        private SpriteRenderer _spriteRenderer;
        private bool _flashingOnce = true;
        private Coroutine flashingCoroutine;
        private void Start()
        {
            _outline = new GameObject();
            _outline.name = "Outline";
            _outline.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Outline");
            _spriteRenderer = _outline.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (!Core.IsStarted) return;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.x = Mathf.Round(mousePosition.x - 0.5f) + 0.5f;
            mousePosition.y = Mathf.Round(mousePosition.y - 0.5f) + 0.5f;
            mousePosition.z = -1;
            _outline.transform.position = mousePosition;
            Core.CurrentCell = GameObject.Find("Grid").GetComponent<Grid>().WorldToCell(mousePosition);
            if (BlockBreaking.IsBreaking)
            {
                if (_flashingOnce)
                {
                    flashingCoroutine = StartCoroutine(Flashing());
                    _flashingOnce = false;
                }
            }
            else
            {
                if (flashingCoroutine != null)
                {
                    StopCoroutine(flashingCoroutine);
                    _spriteRenderer.enabled = true;
                    flashingCoroutine = null;
                }
                _flashingOnce = true;
            }
        }

        private IEnumerator Flashing()
        {
            while (true)
            {
                _spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.1f);
                _spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
