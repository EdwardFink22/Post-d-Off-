using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollControls : MonoBehaviour
{
    public Rigidbody sphere;
    public Transform kart;

    public float speed;
    public float acceleration;
    public float rotate;
    public float steering;
    public float gravity = -10f;
    public float offsetY = .2f;

    private float currentSpeed = 0;  
    private float currentRotate = 0;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {       
        if (Input.GetButton("Fire1"))
            speed = acceleration;

        float xInput = Input.GetAxis("Horizontal");
        if (xInput != 0)
        {
            int dir = xInput > 0 ? 1 : -1;
            float amount = Mathf.Abs(xInput);
            Steer(dir, amount);
        }

        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f);
        speed = 0f;

        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);
        rotate = 0f;
    }

    private void FixedUpdate()
    {
        transform.position = sphere.transform.position - new Vector3(0, offsetY, 0);

        sphere.AddForce(kart.transform.forward * currentSpeed, ForceMode.Acceleration);

        sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);

        RaycastHit hitOn, hitNear;

        Physics.Raycast(transform.position, Vector3.down, out hitOn, 1.1f);
        Physics.Raycast(transform.position, Vector3.down, out hitNear, 2.0f);

        kart.parent.up = Vector3.Lerp(kart.parent.up, hitNear.normal, Time.deltaTime * 8.0f);
        kart.parent.Rotate(0, transform.eulerAngles.y, 0);

    }

    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }
}
