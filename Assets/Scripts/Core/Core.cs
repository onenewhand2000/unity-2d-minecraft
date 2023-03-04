using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace TwoDMinecraft.Core
{
    public class Core : MonoBehaviour
    {
        public static Core Instance;
        public static bool IsStarted;
        public static Vector3Int CurrentCell;
        public static Tilemap Tilemap;
        public static Canvas Canvas;
        public static Dictionary<int, Chunk> Chunks = new Dictionary<int, Chunk>();
        public static GameObject Player;
        public static int PlayerXPosition;

        private void Awake()
        {
            Instance = this;
            IsStarted = false;
            Debug.Log($"The core was awoken. Used {Time.realtimeSinceStartup} second(s).");
        }

        IEnumerator Start()
        {
            gameObject.AddComponent<InputManager>();
            gameObject.AddComponent<Outline>();
            gameObject.AddComponent<BlockBreaking>();
            AsyncOperation loadCamera = SceneManager.LoadSceneAsync("S_Camera", LoadSceneMode.Additive);
            while (!loadCamera.isDone) yield return null;
            AsyncOperation loadWorld = SceneManager.LoadSceneAsync("S_TestNoise", LoadSceneMode.Additive);
            while (!loadWorld.isDone) yield return null;
            AsyncOperation loadUI = SceneManager.LoadSceneAsync("S_UI", LoadSceneMode.Additive);
            while (!loadUI.isDone) yield return null;
            Tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
            Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            IsStarted = true;
            Debug.Log($"The core was started. Used {Time.realtimeSinceStartup} second(s).");
            yield break;
        }

        private void Update()
        {
            if (!IsStarted) return;
            Player = GameObject.Find("Player");
            //var saveContent = Json.GenerateSave();
            //File.Write(Path.Combine(Application.dataPath, "Saves"), "map.dat", saveContent);
            //var readData = File.Read(Path.Combine(Application.dataPath, "Saves", "map.dat"));
            //var readContent = Json.ReadSave(saveContent);
            //Debug.Log(readContent);
        }

        public static float RoundToTheNearestMultiple(float value, float factor)
        {
            return Mathf.Round(value / factor) * factor;
        }
    }
}