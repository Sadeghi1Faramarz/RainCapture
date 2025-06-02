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

        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenAspect;

        screenBoundaryLeft = Camera.main.transform.position.x - (cameraWidth / 2) + playerHalfWidth;
        screenBoundaryRight = Camera.main.transform.position.x + (cameraWidth / 2) - playerHalfWidth;
    }

    void Update()
    {
        if (Camera.main == null) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
        transform.Translate(movement);

        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, screenBoundaryLeft, screenBoundaryRight);
        transform.position = currentPosition;
    }
}