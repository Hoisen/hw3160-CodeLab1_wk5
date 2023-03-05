using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float forceAmount = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * forceAmount);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * forceAmount);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * forceAmount);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * forceAmount);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Door")
        {
            GameManager.instance.GetComponent<ASCIILevelLoad>().DoorHit();
        }

        if (col.tag == "AnotherDoor")
        {
            GameManager.instance.GetComponent<ASCIILevelLoad>().AnotherDoor();
        }
    }
}
