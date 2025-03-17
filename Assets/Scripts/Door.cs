using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player.hasKey)
            {
                Debug.Log("Door Opened! YOU WIN!");
                GameManager gameManager = FindFirstObjectByType<GameManager>();
                gameManager?.WinGame(); // Call a win function in GameManager
            }
            else
            {
                Debug.Log("Door is locked! Find the key!.");
            }
        }
    }
}
