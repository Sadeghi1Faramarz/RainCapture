using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float fallSpeed = 3f;
    public int coinValue = 10; 

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime; //

    
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        

        
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(coinValue);
            }
            else
            {
                Debug.LogError("GameManager Error!");
            }
        

            Destroy(gameObject); //
        }
    }
}