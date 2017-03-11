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

	void Start () {
        rb.GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {

        Move();

	}

    public void Move()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            PlayerPosition = rb.transform.position;
            PlayerPosition = PlayerPosition + new Vector3 (1f,0f,0f) * speed * Time.deltaTime;
            rb.MovePosition(PlayerPosition);
        }

        if (Input.GetButtonDown("Jump") && grounded == true)
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
            StartCoroutine(CollisionCooldown());
        }
    }

    IEnumerator CollisionCooldown()
    {
        speed = speed / 3;
        playerHit = true;
        yield return new WaitForSeconds(2);
        playerHit = false;
        speed = speed * 3;
        yield return new WaitForSeconds(3);
    }

}
