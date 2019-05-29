using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
