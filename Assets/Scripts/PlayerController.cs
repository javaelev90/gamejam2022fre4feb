using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalDir;
    private float verticalDir;
    private Vector2 direction;
    private Vector2 mousePos;
    private Vector2 colliderCenter;
    private BoxCollider2D collider;
    private float force = 5f;
    private bool isMoving;
    private float speed = 1.0f;
    [SerializeField]private GameObject projectilePrefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDir = Input.GetAxis("Horizontal");
        verticalDir = Input.GetAxis("Vertical");
        direction = new Vector2(horizontalDir, verticalDir);
        colliderCenter = transform.TransformPoint(collider.bounds.center);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotateTowards = mousePos - colliderCenter;
        float rotation = Mathf.Atan2(rotateTowards.y, rotateTowards.x);
        float degrees = Mathf.Rad2Deg * rotation;
        transform.rotation = Quaternion.Euler(0, 0, degrees);

        if (horizontalDir != 0 || verticalDir != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKeyDown("space"))
        {
            Camera cam = Camera.main;

            Vector3 mousePos = Input.mousePosition;
            Vector3 aim = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            bullet.transform.LookAt(aim);
            bullet.GetComponent<Rigidbody2D>().AddForce(aim * 50);
        }


    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddForce(direction * force);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 0.1f);
        }

    }
}
