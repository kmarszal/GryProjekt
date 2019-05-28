using UnityEngine;

public class FinishTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().CompleteLevel();
        }

    }
}
