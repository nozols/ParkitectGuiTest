using UnityEngine;

namespace GuiTest
{
    class Main : IMod
    {
        private GameObject _go;

        public string Description
        {
            get
            {
                return "Test for nice GUIs";
            }
        }

        public string Name
        {
            get
            {
                return "GuiTest";
            }
        }

        public void onDisabled()
        {
            Debug.Log("Disabling mod");
            UnityEngine.Object.Destroy(_go);
        }

        public void onEnabled()
        {
            Debug.Log("Enabling mod");
            _go = new GameObject();
            _go.AddComponent<GuiTestBehaviour>();
        }
    }
}
