using UnityEngine;

public class GuardVision : MonoBehaviour
{
    public Transform guardEye;
    public float visionRange = 0.1f;
    public LayerMask playerLayer;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(guardEye.position, Vector2.right, visionRange, playerLayer);

        Debug.DrawRay(guardEye.position, Vector2.right * visionRange, Color.red);

        if (hit.collider != null)
        {
            Debug.Log("Object Hit: " + hit.collider.gameObject.name + " | Tag: " + hit.collider.tag);
        }

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            float distance = Vector2.Distance(guardEye.position, hit.collider.transform.position);
            Debug.Log($"Player Spotted! Distance to guard: {distance:F2}");

            GameManager gameManager = FindFirstObjectByType<GameManager>();
            gameManager?.GameOver(); // This is enough (no need to check null again)
        }
    }
}
