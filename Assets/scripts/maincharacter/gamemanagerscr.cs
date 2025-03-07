using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanagerscr : MonoBehaviour
{
    public static gamemanagerscr gamemanagervar2;
    public characterscr playercharacter;
    public heartuiscr heartuivar;
    // Start is called before the first frame update
    public GameObject victoryCanvas;
    public bool hasKey = false; 
    private bool gameIsOver = false;

    void Start()
    {
        victoryCanvas.SetActive(false);
    }
    void Awake()
    {
        gamemanagervar2=this;
        
    }
    

    // Update is called once per frame
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
        Time.timeScale = 1;
        gameIsOver = true;
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
