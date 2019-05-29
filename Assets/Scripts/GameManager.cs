using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject completeLevelUI;
    public GameObject endGameUI;

    public void EndGame() 
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            endGameUI.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        Time.timeScale = 0;
        completeLevelUI.SetActive(true);
    }
}
