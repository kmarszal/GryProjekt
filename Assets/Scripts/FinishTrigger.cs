using UnityEngine;

public class FinishTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            FindObjectOfType<GameManager>().CompleteLevel();
        }

    }
}
