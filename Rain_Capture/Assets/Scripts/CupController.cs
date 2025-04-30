using UnityEngine;

public class CupController : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed = 5f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        speed = 15.0f;
    }
    void Update()
    {

        // float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        // transform.position += new Vector3(move, 0, 0);
    }

     private void FixedUpdate()
    {
        Movement();   
    }

    public void Movement()
    {
        var moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var forceMovement = new Vector2(moveX, 0);
        rb.AddForce(forceMovement, ForceMode2D.Impulse);
    }

}
