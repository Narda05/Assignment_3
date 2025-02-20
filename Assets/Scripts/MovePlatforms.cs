using Unity.VisualScripting;
using UnityEngine;

public class MovePLataforms : MonoBehaviour
{
    Vector3 start;
    public Vector3 end;
    public float Velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         start = transform.position;
        //end = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position = Vector3.Lerp(start, end + start, (Mathf.Sin(Velocity * Time.time) + 1f) / 2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
       if (Application.isPlaying)
        {
            Gizmos.DrawLine(start, end + start);
        }
        else
        {
            Gizmos.DrawLine(transform.position, end + transform.position);
        }
}
}
