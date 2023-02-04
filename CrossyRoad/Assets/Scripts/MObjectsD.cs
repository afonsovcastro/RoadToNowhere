using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MObjectsD : MonoBehaviour
{
    /*[SerializeField] private float speed;
    public bool islog;
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }*/

    public float minSpeed, maxSpeed;
    private Rigidbody rb;
    private Vector3 newVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        newVelocity = new Vector3(0, 0, Random.Range(minSpeed, maxSpeed));
    }

    void FixedUpdate ()
    {
        rb.velocity = newVelocity;
    }


}
