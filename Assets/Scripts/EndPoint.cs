using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.tag == "Player")
            {
                //GameController.Instance.EndGame();
                GameController.Instance.EndGame();
            }
            else if(other.tag == "EndPoint" && tag == "Player" )
            {
                //GameController.Instance.EndGame();
                GameController.Instance.EndGame();
            }
        }
    }
}
