using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    public float spawnHeightOffset = 1f;

    private float nextSpawnTime = 0f;
    private float minSpawnX; 
    private float maxSpawnX;  
    private float spawnY;

    void Start()
    {
        
        float halfCoinWidth = 0f;
        if (coinPrefab.GetComponent<SpriteRenderer>() != null)
        {
            halfCoinWidth = coinPrefab.GetComponent<SpriteRenderer>().bounds.extents.x;
        }

    
        minSpawnX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + halfCoinWidth;
        maxSpawnX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfCoinWidth;

    
        spawnY = Camera.main.transform.position.y + Camera.main.orthographicSize + spawnHeightOffset;

     
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
      
        if (Time.time >= nextSpawnTime)
        {
            SpawnCoin(); 
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnCoin()
    {
     
        float randomX = Random.Range(minSpawnX, maxSpawnX);

     
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

      
       
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}