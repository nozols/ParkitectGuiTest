using Parkitect.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

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
                //yield return request;
                GameObject obj = request.asset as GameObject;

                object[] objs = obj.GetComponents<object>();
                for(byte i = 0; i < objs.Length; i++)
                {
                    Debug.Log(i + ": " + objs[i].ToString());
                }

                Debug.Log("Creating instance");
                ScriptableObject.CreateInstance<ModUIAssetManager>();
                Debug.Log("Doing thing after instance");
                ScriptableSingleton<ModUIAssetManager>.Instance.myWindowGO = new MyWindow();
                //ModUIAssetManager.Instance.myWindowGO.windowFrame.setContent(obj.GetComponent(UIWindow));

                //asset = obj.GetComponent<UIWindow>();
                //Debug.Log(asset.name);
                //Debug.Log(asset.ToString());
                //Debug.Log(asset.windowFrame.ToString());
                //AssetManager.Instance.registerObject(asset);

                bundle.Unload(false);
                www.Dispose();
                //w = new UIWindow();
                        
            }

            Debug.Log("Finsihed loading assets");
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.F12)) {
                Debug.Log("Click!");
                Debug.Log("Click!");
                //UIWindow window = UIWindowsController.Instance.spawnWindowFromPrefab<UIWindow>(w, (object)null);
                //renameWindow.setName("Dit is een test");
            }
        }

        public void UnloadAssets() {
           // AssetManager.Instance.unregisterObject(asset);
        }
    }
}
