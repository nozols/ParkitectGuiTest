using UnityEngine;
using System.Collections;
using Parkitect.UI;

namespace GuiTest
{
    class GuiTestBehaviour : MonoBehaviour
    {
        public MyWindow mainWindow;
        void Start()
        {
            //ScriptableSingleton<UIAssetManager>.Instance.
            mainWindow = new MyWindow();
            Debug.Log("Starting GuiTestBehaviour");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F4))
            {
                Debug.Log("Click!");
                RenameWindow renameWindow = UIWindowsController.Instance.spawnWindowFromPrefab<RenameWindow>(ScriptableSingleton<UIAssetManager>.Instance.renameWindowGO, (object)null);
                renameWindow.setName("Dit is een test");
            }
        }      
    }
}
