using UnityEngine;

public class TeddyBearCollect : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            var progress = other.GetComponent<PlayerProgress>();
            if (progress != null)
            {
                progress.CollectTeddy();
            }

            
            Destroy(gameObject);
        }
    }
}
