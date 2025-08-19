using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Teleporter : MonoBehaviour
{
    public Canvas messageCanvas;           // Reference to the Canvas object
    public TextMeshProUGUI messageText;    // Reference to the Text element inside the canvas
    public float messageDuration = 2f;


    void Start()
    {
        if (messageCanvas != null)
            messageCanvas.gameObject.SetActive(false); // Hide the message panel at scene start
    }   


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollect coinCollect = other.GetComponent<CoinCollect>();

            if (coinCollect != null && coinCollect.coin >= 5)
            {
                ShowMessage("Teleporting to next scene...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                ShowMessage("Not enough coins! Need 5 to teleport.");
            }
        }
    }

    void ShowMessage(string message)
    {
        if (messageCanvas != null && messageText != null)
        {
            messageCanvas.gameObject.SetActive(true);     // Show the canvas
            messageText.text = message;

            CancelInvoke("HideMessage");
            Invoke("HideMessage", messageDuration);       // Hide after delay
        }
    }

    void HideMessage()
    {
        messageCanvas.gameObject.SetActive(false);        // Hide the canvas
    }
}
