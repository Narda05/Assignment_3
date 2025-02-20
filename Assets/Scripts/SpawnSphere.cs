using UnityEngine;

public class SpawnSphere : MonoBehaviour
{
    public GameObject bolaPrefab; 
    public Transform spawnPoint;  
    public float intervalo = 2f;  

    void Start()
    {
        InvokeRepeating("SpawnBola", 0f, intervalo);
    }

    void SpawnBola()
    {
        Instantiate(bolaPrefab, spawnPoint.position, Quaternion.identity);
    }
}
