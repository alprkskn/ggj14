﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float speed = 0.1f;
    public float specialSpeedConst = 1.0f;
    public float jumpSpeed = 0.1f;
    public float specialJumpConst = 1.0f;
    public float gravity = 20.0f;
    public bool directionForward = true;

    public inventory inventory;

    public double toxicity = 0.00;

    void Update() {
        //CharacterController controller = GetComponent<CharacterController>();
        //if (controller.isGrounded)
        //{
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * speed * specialSpeedConst;
                directionForward = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * speed * specialSpeedConst;
                directionForward = false;
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed * specialSpeedConst;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * speed * specialSpeedConst;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position += transform.up * jumpSpeed * specialJumpConst;
            }
            if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.RightShift))
            {
                //interactions
                // if sandik or kapi then open it
            }
            if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.RightControl))
            {
                //interactions
                // if you can take smt then take it
            }
            if (toxicity >= 100)
            {
                print("Game Over");
            }
        //}
        //transform.position -= transform.up * gravity * Time.deltaTime;
    }

    public void consumeMeth(object meth)
    {
        if(meth.GetType().ToString().CompareTo("LSD") == 0)
        {
            LSD consumedLSD = (LSD)meth;
            toxicity += Random.Range(consumedLSD.minToxicityLevel, consumedLSD.maxToxicityLevel);
        }

        else if (meth.GetType().ToString().CompareTo("smoke") == 0)
        {
            smoke consumedSmoke = (smoke)meth;
            toxicity += Random.Range(consumedSmoke.minToxicityLevel, consumedSmoke.maxToxicityLevel);
        }

        else if (meth.GetType().ToString().CompareTo("mushroom") == 0)
        {
            mushroom consumedMushroom = (mushroom)meth;
            toxicity += Random.Range(consumedMushroom.minToxicityLevel, consumedMushroom.maxToxicityLevel);
        }

        else if (meth.GetType().ToString().CompareTo("vodka") == 0)
        {
            vodka consumedVodka = (vodka)meth;
            toxicity += Random.Range(consumedVodka.minToxicityLevel, consumedVodka.maxToxicityLevel);
        }
    }
}