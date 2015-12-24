using System.Collections;
using UnityEngine;

namespace GuiTest
{
    class MySkin : MonoBehaviour
    {
        GUISkin skin = ScriptableObject.CreateInstance<GUISkin>();
        GUIStyle exitButtonStyle = new GUIStyle();
        private bool isMenuOpen = false;
        string textareac = "I am a textarea";
        string textfieldc = "I am a textfield";
        bool togglestatus = false;
        float slidervalue = 5;
        public Rect WindowRect = new Rect(20, 20, 200, 200);
        private readonly Rect TitleBarRect = new Rect(0, 0, 10000, 20);

        void Start() {
            RectOffset margin = new RectOffset(0, 0, 33, 0);
            Texture2D windowBackground = new Texture2D(15, 15);
            windowBackground.LoadImage(ImageBytes.Window);
            Texture2D buttonBackground = new Texture2D(15, 15);
            buttonBackground.LoadImage(ImageBytes.Button);
            Texture2D exitButtonBackground = new Texture2D(15, 15);
            exitButtonBackground.LoadImage(ImageBytes.ExitButton);
            Texture2D toggleActiveBackground = new Texture2D(15, 15);
            toggleActiveBackground.LoadImage(ImageBytes.ToggleActive);
            Texture2D toggleInactiveBackground = new Texture2D(15, 15);
            toggleInactiveBackground.LoadImage(ImageBytes.ToggleInactive);
            Texture2D textfieldBackground = new Texture2D(15, 15);
            textfieldBackground.LoadImage(ImageBytes.Textfield);

            skin.window.border = new RectOffset(11, 11, 38, 11);
            skin.window.alignment = TextAnchor.UpperLeft;
            skin.window.padding = new RectOffset(8, 8, 6, 6);
            skin.window.normal.background = windowBackground;
            skin.window.normal.textColor = Color.white;
            skin.window.stretchHeight = true;

            skin.button.padding = new RectOffset(10, 10, 2, 2);
            skin.button.margin = new RectOffset(2, 2, 2, 2);
            skin.button.border = new RectOffset(5, 5, 5, 5);
            skin.button.alignment = TextAnchor.MiddleCenter;
            skin.button.fixedHeight = 22;
            skin.button.stretchHeight = false;
            skin.button.normal.background = buttonBackground;

            skin.toggle.border = new RectOffset(12, 12, 12, 12);
            skin.toggle.fixedHeight = 25;
            skin.toggle.fixedWidth = 25;
            skin.toggle.margin = new RectOffset(2, 2, 2, 2);
            skin.toggle.fontSize = 20;
            skin.toggle.contentOffset = new Vector2(27, 0);
            skin.toggle.onActive.background = toggleActiveBackground;
            skin.toggle.normal.background = toggleInactiveBackground;
            skin.toggle.active.background = toggleActiveBackground;

            skin.textField.border = new RectOffset(6, 6, 6, 6);
            skin.textField.margin = new RectOffset(2, 2, 2, 2);
            skin.textField.normal.background = textfieldBackground;
            skin.textField.normal.textColor = Color.white;

            skin.textArea.border = new RectOffset(6, 6, 6, 6);
            skin.textArea.border = new RectOffset(2, 2, 2, 2);
            skin.textArea.normal.background = textfieldBackground;
            skin.textArea.normal.textColor = Color.white;

            //EXITBUTTON
            exitButtonStyle.border = new RectOffset(5, 5, 5, 5);
            exitButtonStyle.normal.background = exitButtonBackground;
            skin.button.padding = new RectOffset(15, 1, 1, 1);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F9))
            {
                isMenuOpen = !isMenuOpen;
                Debug.Log("Toggle window: " + isMenuOpen);
            }
        }

        void OnGUI()
        {
            GUI.skin = skin;
            if (isMenuOpen)
            {
                WindowRect = GUILayout.Window(31415, WindowRect, DrawWindow, "Guiskin demo");
            }
        }

        public void DrawWindow(int windowID)
        {
            
            if (GUI.Button(new Rect(WindowRect.width - 21, 6, 15, 15), "", exitButtonStyle))
            {
                isMenuOpen = false;
            }
            GUI.BeginGroup(new Rect(0, 27, WindowRect.width, WindowRect.height - 33));
            GUILayout.BeginHorizontal();
            GUILayout.Button("I am a button");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("I am a label");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.RepeatButton("I am a repeat button");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            textareac = GUILayout.TextArea(textareac);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            textfieldc = GUILayout.TextField(textfieldc);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            togglestatus = GUILayout.Toggle(togglestatus, "Hello");
            //GUILayout.Label("This is a toggler");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            slidervalue = GUILayout.VerticalSlider(slidervalue, 0, 10);
            GUILayout.EndHorizontal();

            GUI.EndGroup();
            GUI.DragWindow(TitleBarRect);

        }

        private IEnumerator SpawnGuests()
        {
            for (;;)
            {
                GameController.Instance.park.spawnGuest();
                yield return new UnityEngine.WaitForSeconds(1);
            }

        }
    }
}
