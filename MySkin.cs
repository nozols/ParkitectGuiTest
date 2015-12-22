using System.Collections;
using UnityEngine;

namespace GuiTest
{
    class MySkin : MonoBehaviour
    {
        GUISkin skin = ScriptableObject.CreateInstance<GUISkin>();
        GUIStyle exitButtonStyle = new GUIStyle();
        private bool isMenuOpen = false;
        public Rect WindowRect = new Rect(20, 20, 200, 200);
        private readonly Rect TitleBarRect = new Rect(0, 0, 10000, 20);

        void Start() {
            RectOffset margin = new RectOffset(0, 0, 33, 0);
            Texture2D windowBackground = new Texture2D(15, 15);
            windowBackground.LoadImage(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 24, 0, 0, 0, 52, 8, 6, 0, 0, 0, 144, 25, 248, 181, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 0, 24, 116, 69, 88, 116, 83, 111, 102, 116, 119, 97, 114, 101, 0, 112, 97, 105, 110, 116, 46, 110, 101, 116, 32, 52, 46, 48, 46, 54, 252, 140, 99, 223, 0, 0, 1, 26, 73, 68, 65, 84, 88, 71, 237, 151, 49, 14, 194, 48, 16, 4, 253, 82, 58, 106, 62, 66, 205, 11, 232, 249, 2, 13, 239, 50, 186, 196, 38, 151, 203, 248, 98, 147, 40, 69, 228, 147, 166, 65, 222, 25, 218, 132, 24, 163, 203, 253, 249, 136, 30, 97, 237, 254, 145, 150, 72, 202, 249, 237, 37, 207, 36, 237, 116, 53, 242, 203, 237, 138, 208, 91, 33, 169, 199, 243, 228, 36, 37, 104, 155, 244, 99, 128, 30, 144, 200, 131, 28, 197, 0, 9, 106, 176, 30, 12, 208, 176, 5, 237, 26, 2, 250, 7, 129, 70, 45, 88, 223, 174, 255, 62, 163, 157, 61, 128, 104, 103, 15, 32, 218, 121, 178, 128, 64, 131, 22, 172, 239, 248, 128, 64, 195, 26, 200, 133, 1, 129, 4, 30, 228, 16, 138, 1, 129, 68, 4, 109, 51, 110, 32, 67, 82, 129, 222, 90, 170, 2, 91, 232, 129, 85, 170, 2, 175, 247, 7, 161, 183, 22, 55, 64, 82, 130, 182, 153, 98, 128, 68, 30, 228, 16, 48, 64, 130, 26, 200, 181, 8, 208, 176, 5, 235, 59, 89, 128, 6, 255, 160, 157, 61, 128, 104, 103, 15, 32, 218, 121, 108, 64, 160, 65, 11, 214, 183, 248, 8, 164, 81, 11, 218, 53, 124, 4, 210, 103, 44, 13, 107, 176, 158, 98, 64, 32, 129, 7, 57, 126, 129, 173, 17, 218, 14, 114, 185, 28, 40, 69, 4, 146, 10, 244, 86, 72, 234, 241, 116, 192, 139, 212, 146, 180, 211, 217, 192, 150, 72, 82, 206, 143, 2, 26, 18, 105, 146, 166, 112, 33, 124, 1, 63, 143, 210, 171, 251, 236, 219, 228, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 });
            Texture2D buttonBackground = new Texture2D(15, 15);
            buttonBackground.LoadImage(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 11, 0, 0, 0, 11, 8, 6, 0, 0, 0, 169, 172, 119, 38, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 0, 24, 116, 69, 88, 116, 83, 111, 102, 116, 119, 97, 114, 101, 0, 112, 97, 105, 110, 116, 46, 110, 101, 116, 32, 52, 46, 48, 46, 54, 252, 140, 99, 223, 0, 0, 0, 121, 73, 68, 65, 84, 40, 83, 149, 145, 65, 10, 128, 32, 16, 69, 103, 21, 29, 58, 136, 22, 33, 69, 187, 44, 133, 144, 238, 225, 214, 107, 21, 147, 223, 172, 85, 153, 61, 24, 229, 235, 67, 116, 36, 102, 14, 85, 139, 158, 103, 165, 216, 57, 119, 151, 210, 154, 155, 110, 216, 22, 99, 10, 2, 16, 125, 240, 211, 59, 102, 93, 247, 170, 21, 37, 249, 33, 46, 165, 129, 71, 163, 148, 49, 166, 145, 211, 196, 100, 173, 141, 49, 13, 60, 194, 67, 114, 128, 247, 239, 228, 220, 59, 195, 251, 215, 13, 240, 213, 103, 236, 7, 241, 226, 233, 7, 145, 177, 126, 26, 68, 7, 180, 255, 155, 219, 104, 114, 72, 30, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 });

            skin.window.border = new RectOffset(11, 11, 38, 11);
            skin.window.alignment = TextAnchor.UpperLeft;
            skin.window.fontStyle = FontStyle.Bold;
            skin.window.margin = new RectOffset(9, 9, 9, 9);
            skin.window.padding = new RectOffset(10, 10, 6, 10);
            skin.window.normal.background = windowBackground;
            skin.window.normal.textColor = Color.white;

            skin.button.padding = new RectOffset(10, 10, 2, 2);
            skin.button.margin = margin;
            skin.button.border = new RectOffset(5, 5, 5, 5);
            skin.button.normal.background = buttonBackground;

            skin.label.margin = margin;

            //EXITBUTTON
            exitButtonStyle.border = new RectOffset(5, 5, 5, 5);
            exitButtonStyle.normal.background = buttonBackground;
            skin.button.padding = new RectOffset(5, 1, 1, 1);
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
            
            if (GUI.Button(new Rect(WindowRect.width - 21, 6, 15, 15), "X", exitButtonStyle))
            {
                isMenuOpen = false;
            }
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Give $1K"))
            {
                GameController.Instance.park.parkInfo.moneyTransaction(1000, MonthlyTransactions.Transaction.WAGES);
            }
            if (GUILayout.Button("Give $10K"))
            {
                GameController.Instance.park.parkInfo.moneyTransaction(10000, MonthlyTransactions.Transaction.WAGES);
            }
            if (GUILayout.Button("Give $100K"))
            {
                GameController.Instance.park.parkInfo.moneyTransaction(100000, MonthlyTransactions.Transaction.WAGES);
            }
            if (GUILayout.Button("Give $1M"))
            {
                GameController.Instance.park.parkInfo.moneyTransaction(1000000, MonthlyTransactions.Transaction.WAGES);
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Set speed (1x)"))
            {
                Time.timeScale = 1;
            }
            if (GUILayout.Button("Set speed (5x)"))
            {
                Time.timeScale = 5;
            }
            if (GUILayout.Button("Set speed (10x)"))
            {
                Time.timeScale = 10;
            }
            if (GUILayout.Button("Set speed (15x)"))
            {
                Time.timeScale = 15;
            }
            GUILayout.EndHorizontal();
            GUILayout.Label("Current speed: " + Time.timeScale);

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
