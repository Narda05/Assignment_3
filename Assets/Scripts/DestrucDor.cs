using UnityEngine;

public class DestrucDor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
