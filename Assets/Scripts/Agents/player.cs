using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    public float speed = 6.0f;
    public float specialSpeedConst = 1.0f;
    public float jumpSpeed = 8.0f;
    public float specialJumpConst = 1.0f;
    public float gravity = 20.0f;
    public bool directionForward = true;

    public inventory inventory;
    
    public bool LSD = false;
    public bool smoke = false;
    public bool mushroom = false;
    public bool vodka = false;

    public float toxicity = 0.0f;
    
    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
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
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.up * jumpSpeed * specialJumpConst;
            }
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.RightShift))
            {
                //interactions
                // if sandik or kapi then open it
            }
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.RightControl))
            {
                //interactions
                // if you can take smt then take it
            }
        }
        transform.position -= transform.up * gravity * Time.deltaTime;
    }
}
