using UnityEngine;
using TMPro;
public class TeddyBearCollect : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Teddy collected!");
            Destroy(gameObject);
        }
    }
}
