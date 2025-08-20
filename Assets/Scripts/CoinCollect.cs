using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using System.Collections;

public class CoinCollect : MonoBehaviour
{
    // This script handles coin collection and score management in the game.
    public int coin;
    public TextMeshProUGUI scoreText;

    // Audio clip for coin collection sound
    public AudioClip coinSound;
    private AudioSource audioSource;

    public TextMeshProUGUI gameOverText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // This method is called when the player collides with a coin or hazard.
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
        else if (other.CompareTag("Pill"))
        {
            coin += 5;
            UpdateScoreUI();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Hazard")) // Handle collision with hazards
        {
            coin = Mathf.Max(0, coin - 1);
            UpdateScoreUI();
            if (coin == 0)
            {
                StartCoroutine(LevelRestart());
            }
        }
    }




    IEnumerator LevelRestart() // Coroutine to handle level restart after game over
    {
        if (gameOverText != null)
        {
            gameOverText.text = "Game Over!";
            gameOverText.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + coin.ToString();
    }
}
