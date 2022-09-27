using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public float speed = 30;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        float y = Input.GetAxis("Vertical");

        body.velocity = new Vector2(x, y) * speed;
    }
}
