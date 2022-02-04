using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] float speedModifier;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody2D>().AddRelativeForce(transform.forward * speedModifier);
    }
}
