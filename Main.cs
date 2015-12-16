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
            _go.GetComponent<AssetLoader>().UnloadAssets();

            UnityEngine.Object.Destroy(_go);
        }

        public void onEnabled()
        {
            _go = new GameObject();
            _go.AddComponent<AssetLoader>();
            _go.GetComponent<AssetLoader>().Path = Path;
            _go.GetComponent<AssetLoader>().Identifier = Indentifier;
            _go.GetComponent<AssetLoader>().LoadAssets();

            _go.AddComponent<GuiTestBehaviour>();
            
        }

        public string Path { get; set; }
        public string Indentifier { get; set; }
    }
}
