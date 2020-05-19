﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //gets the rigidbody component.
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //moves horizontal when the horizontal key is pressed
        float moveVertical = Input.GetAxis("Vertical"); //moves vertical when the vertical key is pressed

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed); //adds force to the players movement by * the speed set.
    }
    void OnTriggerEnter(Collider other) //triggers when the player is in collision
    {
        if (other.gameObject.CompareTag("Pick Up")) //called everytime we touch a trigger collider and if the tag is the same as pick up = set active false.
        {
            other.gameObject.SetActive(false);
        }

    }
    void Update() //game over=reset to scene 1
    {
        if(rb.velocity.y<-20) //if the players velocity on the y axis reaches below -50 then.. 
        {
            SceneManager.LoadScene("Level1"); //load said scene

        }
    }



}