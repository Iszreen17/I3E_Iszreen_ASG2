using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public static bool isRestarting = false;

    public bool isDead = false;


void Start()
{


    if (GameManager.instance != null)
    {
        currentHealth = GameManager.instance.playerHealth;
    }
    else
    {
        Debug.LogWarning("GameManager instance is null!");
        currentHealth = maxHealth;
    }

    if (healthBar != null)
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }
    else
    {
        Debug.LogWarning("HealthBar is not assigned in the Inspector!");
    }
}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            TakeDamage(20);
        }

    }

    void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        GameManager.instance.playerHealth = currentHealth;
        healthBar.SetHealth(currentHealth);

        
        if (currentHealth <= 0)
        {
            PlayerKill();
        }
    }

    void PlayerKill()
    {
        isDead = true;
        Debug.Log("Player has died");
        StartCoroutine(RestartLevelCoroutine());
    }

    IEnumerator RestartLevelCoroutine()
    {   
        isRestarting = true;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
