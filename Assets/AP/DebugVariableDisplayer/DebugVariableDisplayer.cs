using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AP.DebugVariableDisplayer
{
    public class DebugVariableDisplayer : MonoBehaviour
    {
        private static List<System.Type> supportType = new List<System.Type>();
        private GameObject canvasGameObject;
        private RectTransform canvasRectTransform;
        private GameObject boxGameObject;
        private RectTransform boxRectTransform;
        private GameObject textGameObject;
        private TMPro.TMP_Text textTMPText;
        private RectTransform textRectTransform;
        private static string template;
        private static List<string> list = new List<string>();
        string a = "";

        private void Awake()
        {
            supportType.Add(typeof(bool));
            supportType.Add(typeof(float));
            supportType.Add(typeof(int));
            supportType.Add(typeof(string));
            supportType.Add(typeof(Vector2));
            supportType.Add(typeof(Vector3));
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            canvasGameObject = gameObject.transform.GetChild(0).gameObject;
            canvasRectTransform = canvasGameObject.GetComponent<RectTransform>();
            boxGameObject = gameObject.transform.GetChild(0).GetChild(0).gameObject;
            boxRectTransform = boxGameObject.GetComponent<RectTransform>();
            textGameObject = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            textTMPText = textGameObject.GetComponent<TMPro.TMP_Text>();
            textRectTransform = textGameObject.GetComponent<RectTransform>();
        }

        private void Update()
        {
            textRectTransform.sizeDelta = boxRectTransform.sizeDelta;
            boxRectTransform.position = new Vector2(canvasRectTransform.sizeDelta.x - boxRectTransform.sizeDelta.x / 2, canvasRectTransform.sizeDelta.y - boxRectTransform.sizeDelta.y / 2);
            ShowVariable("SizeDelta", canvasRectTransform.sizeDelta);
        }

        private void LateUpdate()
        {
            list.Sort();
            foreach (var item in list)
            {
                if (template != "") template += "\n";
                template += item;
            }
            textTMPText.text = template;
            template = "";
            list.Clear();
        }

        public static void ShowVariable<T>(string description, T value)
        {
            bool isSupported = false;
            foreach (var type in supportType)
            {
                if (type == typeof(T))
                {
                    isSupported = true;
                }
            }
            if (!isSupported)
            {
                Debug.LogError(typeof(T) + " is NOT supported.");
                return;
            }
            list.Add($"{description}: {value}");
        }
    }
}
