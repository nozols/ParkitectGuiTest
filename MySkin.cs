using System.Collections;
using UnityEngine;

namespace GuiTest
{
    class MySkin : MonoBehaviour
    {
        GUISkin skin = ScriptableObject.CreateInstance<GUISkin>();
        private bool isMenuOpen = false;
        public Rect WindowRect = new Rect(20, 20, 200, 200);
        private readonly Rect TitleBarRect = new Rect(0, 0, 10000, 20);

        void Start() {
            skin.label.normal.textColor = Color.green;
            skin.window.normal.textColor = Color.grey;
            skin.button.fontStyle = FontStyle.Bold;
            skin.button.normal.textColor = Color.red;
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
            if (isMenuOpen)
            {
                WindowRect = GUILayout.Window(31415, WindowRect, DrawWindow, "Cheat mod options");
            }
        }

        public void DrawWindow(int windowID)
        {
            GUI.skin = skin;
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
