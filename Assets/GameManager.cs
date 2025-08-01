using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerScore = 0;
    public int playerHealth = 100;

    void Awake()
    {
        // Singleton pattern to keep one instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
