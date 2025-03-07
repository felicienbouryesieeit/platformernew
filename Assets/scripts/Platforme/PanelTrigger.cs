using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PanelTrigger : MonoBehaviour
{
    public GameObject panelUI;
    public TMP_Text hintText;

    public string message = "Indice : Utilise les flèches pour sauter plus loin !";

    private bool isPaused = false;

    void Start()
    {
        if (panelUI != null)
        {
            panelUI.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerbehavior playerbehaviorvar = other.GetComponent<playerbehavior>();
        if (playerbehaviorvar!= null)
        {
            ShowMessage();
        }
    }

    void ShowMessage()
    {
        if (panelUI != null)
        {
            panelUI.SetActive(true);
            hintText.text = message;
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    void Update()
    {
        if (isPaused && Input.GetKeyDown(KeyCode.Return))
        {
            ResumeGame();
        }
    }

    void ResumeGame()
    {
        if (panelUI != null)
        {
            panelUI.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
