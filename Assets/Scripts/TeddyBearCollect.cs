using UnityEngine;
using TMPro;
public class TeddyBearCollect : MonoBehaviour
{
    public TextMeshProUGUI congratsText;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Teddy collected!");
            if (congratsText != null)
            {
                congratsText.text = "Congratulations! You collected the Teddy Bear!";
                congratsText.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
