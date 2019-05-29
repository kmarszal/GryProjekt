using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Image health;
    public int maxHealth;

    // Update is called once per frame
    void Update()
    {
        int playerHealth = FindObjectOfType<PlayerController>().health;
        Debug.Log(playerHealth);
        health.fillAmount = Mathf.Max(0f, playerHealth) / (float) maxHealth;

    }
}
