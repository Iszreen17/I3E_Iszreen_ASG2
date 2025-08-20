using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{

    public TextMeshProUGUI congratsText;
    private bool teddyCollected = false;

    public void CollectTeddy()
    {
        teddyCollected = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Final") && teddyCollected)
        {
            if (congratsText != null)
            {
                congratsText.text = "Congratulations! You collected the Teddy Bear!";
                congratsText.gameObject.SetActive(true);
            }
        }
    }

}
