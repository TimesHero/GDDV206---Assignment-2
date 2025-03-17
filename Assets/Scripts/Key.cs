using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Key Picked Up!");
            other.GetComponent<PlayerController>().hasKey = true; // Set hasKey to true
            Destroy(gameObject); // Remove the key
        }
    }
}
