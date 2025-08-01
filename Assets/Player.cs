using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

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
         Invoke("RestartLevel", 1.5f);
    }

    void RestartLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene(1));
    }

}
