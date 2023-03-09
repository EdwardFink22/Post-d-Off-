using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTex : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public MeshRenderer display;
    // Update is called once per frame
    void Update()
    {
        display.material.mainTextureOffset = new Vector2(speedX, speedY) * Time.time;
    }
}
