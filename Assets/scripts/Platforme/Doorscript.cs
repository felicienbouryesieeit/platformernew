using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameManager.hasKey)
        {
            gameManager.ShowVictory();
        }
    }
}
