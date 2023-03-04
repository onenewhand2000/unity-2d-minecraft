using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TwoDMinecraft.Core.UI.Inventory
{
    public class InventoryBox : MonoBehaviour
    {
        Image image;

        private IEnumerator Start()
        {
            yield return new WaitForCoreStart();
            Debug.Log(Core.Canvas.gameObject.GetComponent<RectTransform>().sizeDelta);
            image = gameObject.GetComponent<Image>();
            image.enabled = false;
        }

        private void Update()
        {
            if (!Core.IsStarted) return;
            Vector2 canvasSize = Core.Canvas.gameObject.GetComponent<RectTransform>().sizeDelta;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((canvasSize.y - 20) / 1.25f, canvasSize.y - 20);
            if (Input.GetKeyDown(KeyCode.E)) image.enabled = !image.enabled;
        }
    }
}
