using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float screenBoundary;

    private void Start()
    {
    
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfWidth;
    }

    private void Update()
    {
    
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

    
        transform.Translate(move, 0, 0);

    
        float clampedX = Mathf.Clamp(transform.position.x, -screenBoundary, screenBoundary);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}