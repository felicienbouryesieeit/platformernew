using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.PlayerHasKey();
            Destroy(gameObject);
        }
    }
}
