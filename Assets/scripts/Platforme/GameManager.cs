using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public GameObject victoryCanvas;
    public bool hasKey = false; 
    private bool gameIsOver = false;

    void Start()
    {
        victoryCanvas.SetActive(false);
    }

    void Update()
    {
        if (hasKey && !gameIsOver && Input.GetKeyDown(KeyCode.E))
        {
            ShowVictory();
        }
    }

    public void PlayerHasKey()
    {
        hasKey = true;
    }

    public void ShowVictory()
    {
        victoryCanvas.SetActive(true);
        Time.timeScale = 0;
        gameIsOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
