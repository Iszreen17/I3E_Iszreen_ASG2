using UnityEngine;

public class WelcomeMessage : MonoBehaviour
{
    public GameObject welcomeCanvas;

    void Start()
    {
        if (Player.isRestarting)
        {
            welcomeCanvas.SetActive(false);
            Player.isRestarting = false; // Reset for future clean starts
        }
        else
        {
            welcomeCanvas.SetActive(true);
        }
    }
}
