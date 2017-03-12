using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float force;

    private Vector3 PlayerPosition;

    bool grounded = false;
    bool playerHit = false;

    public float timer; // set how long you want to slow down your player;
    private float originalTime;
    private float originalSpeed;

    void Start () {
        rb.GetComponent<Rigidbody>();
        originalSpeed = speed;
        originalTime = timer;
	}
	
	void FixedUpdate () {

        Move();
        SlowDown();
	}

    void SlowDown()
    {
        if (playerHit == true)
        {
            speed = speed / 3; //Slow down character
            timer -= Time.deltaTime; // count down
            if (timer <= 0)
            {
                speed = originalSpeed;
                playerHit = false;
                timer = originalTime;
            }
        }
    }

    public void Move()
    {
        if (Input.GetButtonDown("P1Horizontal"))
        {
            PlayerPosition = rb.transform.position;
            PlayerPosition = PlayerPosition + new Vector3 (1f,0f,0f) * speed * Time.deltaTime;
            rb.MovePosition(PlayerPosition);

        }

        if (Input.GetButtonDown("P1Jump") && grounded == true)
        {
            rb.AddForce(new Vector3(0f, force, 0f), ForceMode.Impulse);
            grounded = false;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Ground")
        {
            grounded = true;
        }

        else { grounded = false; }
        
        if (coll.tag == "Obstacle")
        {
            playerHit = true;
        }
    }
}