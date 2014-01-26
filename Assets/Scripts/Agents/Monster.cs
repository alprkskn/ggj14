using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
    public Transform target;
    public Transform self;

    public float speed = 0.2f;
    public float jumpSpeed = 0.5f;
    public float specialJumpConst = 1.0f;
    public float gravity = 20.0f;
    public bool directionForward = true;

    void Awake()
    {
        self = transform;
    }

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        self.position += self.forward * speed;
	}
}
