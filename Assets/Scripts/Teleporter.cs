using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollect coinCollect = other.GetComponent<CoinCollect>();

            if (coinCollect != null && coinCollect.coin >= 12)
            {
                Debug.Log("Enough coins collected. Teleporting to next scene!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("Not enough coins! Need 12 to teleport.");
            }
        }
        
    }
}
