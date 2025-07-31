using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    public int coin;
    public TextMeshProUGUI scoreText;

    public AudioClip coinSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coin += 1;
            UpdateScoreUI();
            if (coinSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(coinSound);
            }
            Destroy(other.gameObject);
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + coin.ToString();
    }

}
