using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OPEN");
            doors.SetActive(false);
        }

    }
}
