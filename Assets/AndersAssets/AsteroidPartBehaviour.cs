using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPartBehaviour : MonoBehaviour
{

    [SerializeField] int asteroidHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(asteroidHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            asteroidHealth--;
        }
    }
}
