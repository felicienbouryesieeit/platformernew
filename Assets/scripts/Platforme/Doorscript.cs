using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        playerbehavior playerbehaviorvar = other.GetComponent<playerbehavior>();
        if (playerbehaviorvar!= null)
        {
            gameManager.ShowVictory();
        }
    }
}
