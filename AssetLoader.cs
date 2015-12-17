using Parkitect.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GuiTest
{
    class AssetLoader : MonoBehaviour
    {
        public string Path;
        public string Identifier;

        public UIWindow w;

        public UIWindow asset;

        public void LoadAssets() {
            Debug.Log("Start loading assets");

            char dsc = System.IO.Path.DirectorySeparatorChar;

            using (WWW www = new WWW("file://" + Path + dsc + "Assets" + dsc + "gui")) {
                if (www.error != null) {
                    throw new Exception("Loading had an error: " + www.error);
                }

                AssetBundle bundle = www.assetBundle;
                AssetBundleRequest request = bundle.LoadAssetAsync("Canvas", typeof(GameObject));
                GameObject obj = request.asset as GameObject;
                CanvasScaler c = obj.GetComponent<CanvasScaler>();
                LogComponents(obj);
                Debug.Log(obj.GetComponent<GameObject>());
                Debug.Log(c.ToString());

                Debug.Log("Creating instanceof ModUIAssetManager");
                ScriptableObject.CreateInstance<ModUIAssetManager>();

                bundle.Unload(false);
                www.Dispose();  
            }

            Debug.Log("Finsihed loading assets");
        }

        void LogComponents(GameObject obj) {
            object[] objs = obj.GetComponents<object>();
            for (int i = 0; i < objs.Length; i++) {
                Debug.Log(i + ": " + objs[i].ToString());
            }
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.F12)) {
                //Debug.Log("Opening my window");
            }
        }

        public void UnloadAssets() {
           
        }
    }
}
