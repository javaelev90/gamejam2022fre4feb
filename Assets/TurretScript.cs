using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float range;
    public Transform target;
    bool Detected = false;

    Vector2 dir;

    public GameObject Gun;
    public GameObject Bullet;
    public float fireRate;
    public float nextTimeToFire = 0;
    public Transform shootPPoint;
    public float force;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetpos = target.position;

        dir = targetpos - (Vector2)transform.position;

        RaycastHit2D rayinfo = Physics2D.Raycast(transform.position, dir, range);
        if (rayinfo)
        {
            if (rayinfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                    print("Detected");
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        }

        if (Detected )
        {
            Gun.transform.up = dir;
            if(Time.time> nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                shoot();
            }
        }
    }

    private void shoot()
    {
        GameObject bulletInts = Instantiate(Bullet, shootPPoint.position, Quaternion.identity);
        bulletInts.GetComponent<Rigidbody2D>().AddForce(dir * force); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
