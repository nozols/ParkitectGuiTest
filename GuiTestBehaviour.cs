using UnityEngine;
using System.Collections;

namespace GuiTest
{
    class GuiTestBehaviour : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Starting mod");
            StartCoroutine(SpawnGuests());
        }

        private IEnumerator SpawnGuests()
        {
            for (;;)
            {
                Debug.Log("Spawning Guests");
                GameController.Instance.park.spawnGuest();

                yield return new UnityEngine.WaitForSeconds(1);
            }
        }
    }
}
