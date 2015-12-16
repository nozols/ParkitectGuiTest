using UnityEngine;

namespace GuiTest
{
    public class Main : IMod
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
            UnityEngine.Object.Destroy(_go);
        }

        public void onEnabled()
        {
            _go = new GameObject();
            _go.AddComponent<GuiTestBehaviour>();
        }
    }
}
