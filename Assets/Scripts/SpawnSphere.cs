using UnityEngine;

public class SpawnSphere : MonoBehaviour
{
    public GameObject bolPrefab; 
    public Transform spawnPoint;  
    public float interval = 2f;  

    void Start()
    {
        InvokeRepeating("SpawnBol", 0f, interval);
    }

    void SpawnBol()
    {
        Instantiate(bolPrefab, spawnPoint.position, Quaternion.identity);
    }
}
