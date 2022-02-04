using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] List<GameObject> asteroidParts;
    [SerializeField] Vector2 movementSpeedModifier;
    [SerializeField] int asteroidHealth = 2;
    bool enabledParts = false;
    Rigidbody2D rigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector2 movementSpeed = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4)) * movementSpeedModifier;
        float rotationsModifier = Random.Range(-6, 6);
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(movementSpeed);
        rigidbody2D.AddTorque(rotationsModifier);
    }


    // Update is called once per frame
    void Update()
    {
        if(asteroidHealth <= 0 && !enabledParts)
        {
            gameObject.SetActive(false);
            foreach (GameObject part in asteroidParts)
            {
                part.gameObject.SetActive(true);
                part.transform.parent = null;
                Vector2 movementSpeed = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4)) * movementSpeedModifier;
                float rotationsModifier = Random.Range(-6, 6);
                part.GetComponent<Rigidbody2D>().AddForce(movementSpeed);
                part.GetComponent<Rigidbody2D>().AddTorque(rotationsModifier);
            }
            enabledParts = true;
            Destroy(this);
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
