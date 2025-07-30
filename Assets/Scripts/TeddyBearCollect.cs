using UnityEngine;

public class TeddyBearCollect : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Teddy collected! Head to the exit");
            Destroy(gameObject);
        }
    }
}
