using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] int numberOfAsteroids;
    // Start is called before the first frame update
    void Start()
    {
        while(numberOfAsteroids >= 0)
        {
            Instantiate(asteroidPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0f), Quaternion.identity);
            numberOfAsteroids--;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
