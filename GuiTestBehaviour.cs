using UnityEngine;
using System.Collections;
using Parkitect.UI;

namespace GuiTest
{
    class GuiTestBehaviour : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Starting GuiTestBehaviour");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                Debug.Log("Opening Renamewindow");
                RenameWindow renameWindow = UIWindowsController.Instance.spawnWindowFromPrefab<RenameWindow>(ScriptableSingleton<UIAssetManager>.Instance.renameWindowGO, (object)null);
                renameWindow.setName("This is a test");
            }
        }      
    }
}
