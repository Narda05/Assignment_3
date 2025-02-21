using UnityEngine;

public class SpherePart4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillVolume")) 
        {
            Destroy(gameObject); 
        }
    }
}
