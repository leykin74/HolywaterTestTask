using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addCoins : MonoBehaviour
{
    public Transform coin;
    public Vector2 spawnSizes;
    public int maxCoins = 5;
    public float spawnInterval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        startSpawningCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCoins()
    {
        if (GameObject.FindGameObjectsWithTag("Coin").Length < maxCoins)
        {
            float left, right, top, bottom;
            left = transform.position.x - spawnSizes.x/2;
            right = transform.position.x + spawnSizes.x/2;
            top = transform.position.z + spawnSizes.y/2;
            bottom = transform.position.z - spawnSizes.y/2;
            
            float x = Random.Range(left, right);
            float z = Random.Range(bottom, top);
            Vector3 pos = new Vector3(x, transform.position.y, z);
            Transform _coin = Instantiate(coin, pos, Quaternion.identity);
            _coin.parent = transform;
        }
    }

    public void startSpawningCoins()
    {
        InvokeRepeating("spawnCoins", 0, spawnInterval);
    }
}
