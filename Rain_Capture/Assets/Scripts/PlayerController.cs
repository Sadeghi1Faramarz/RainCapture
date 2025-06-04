using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000f;
    private float screenBoundaryLeft;
    private float screenBoundaryRight;
    private float playerHalfWidth;

    void Start()
    {
        if (Camera.main == null)
        {
            enabled = false;
            return;
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            playerHalfWidth = spriteRenderer.bounds.extents.x;
        }
        else
        {
            playerHalfWidth = 0.5f;
        }

        Vector3 leftEdgeScreenPoint = new Vector3(0, Screen.height / 2, Camera.main.transform.position.z - transform.position.z);
        screenBoundaryLeft = Camera.main.ScreenToWorldPoint(leftEdgeScreenPoint).x + playerHalfWidth;

        Vector3 rightEdgeScreenPoint = new Vector3(Screen.width, Screen.height / 2, Camera.main.transform.position.z - transform.position.z);
        screenBoundaryRight = Camera.main.ScreenToWorldPoint(rightEdgeScreenPoint).x - playerHalfWidth;
    }

    void Update()
    {
        if (Camera.main == null) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
        
        Vector3 newPosition = transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, screenBoundaryLeft, screenBoundaryRight);
        transform.position = newPosition;
    }
}