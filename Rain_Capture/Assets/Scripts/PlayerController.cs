using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveX, 0, 0);
        transform.position += movement * speed * Time.deltaTime;
    }
}
