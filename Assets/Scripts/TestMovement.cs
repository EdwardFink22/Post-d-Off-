using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed;
    public float turnSpeed = 45;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        body.velocity = transform.forward * y * speed;
        transform.Rotate(transform.up * x * Time.deltaTime * turnSpeed);

    }
}
