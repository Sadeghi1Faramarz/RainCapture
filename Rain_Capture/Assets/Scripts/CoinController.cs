using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float fallSpeed = 3f;
    public int coinValue = 10;
    private float offScreenYBoundary = -6f;

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y < offScreenYBoundary)
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.SubtractScore(coinValue);
            }
            else
            {
                Debug.LogError("CoinController: GameManager instance not found! Score not subtracted for missed coin.");
            }
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
                Debug.LogError("CoinController: GameManager instance not found! Score not added for collected coin.");
            }
            Destroy(gameObject);
        }
    }
}