﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public Animator anim;
    public AudioSource aud;
    public float speed;
    public float force;
    public KeyCode player1HButton;
    public KeyCode player1JButton;

    private Vector3 PlayerPosition;
    private KeyCode[] buttonsp1h;
    private KeyCode[] buttonsp1j;
    private List<KeyCode> buttons = new List<KeyCode>();


    bool grounded = false;
   public bool playerHit = false;

    public float timer; // set how long you want to slow down your player;
    private float originalTime;
    private float originalSpeed;

    public float ButtonTimer;
    private float originalButtonTimer;

    void Awake()
    {
        aud.GetComponent<AudioSource>();
        anim.GetComponent<Animator>();
        rb.GetComponent<Rigidbody>();
        originalSpeed = speed;
        originalTime = timer;
        buttonsp1j = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.A, KeyCode.S, };
        buttonsp1h = new KeyCode[] { KeyCode.D, KeyCode.F, KeyCode.V, KeyCode.C, KeyCode.X, KeyCode.Z };
        originalButtonTimer = ButtonTimer;
    }

    void Start () {
        player1HButton = buttonsp1h[Random.Range(0, buttonsp1h.Length)];
        player1JButton = buttonsp1j[Random.Range(0, buttonsp1j.Length)];
    }

    void Update()
    {
        resetButtons();
    }

    void FixedUpdate () {

        movePlayer1();
        //Move();
        SlowDown();
	}

    void ResetButtons()
    {
        buttons.Clear();
        buttons.Add(KeyCode.Q);
        buttons.Add(KeyCode.W);
        buttons.Add(KeyCode.E);
        buttons.Add(KeyCode.R);
        buttons.Add(KeyCode.T);
        buttons.Add(KeyCode.A);
        buttons.Add(KeyCode.S);
        buttons.Add(KeyCode.D);
        buttons.Add(KeyCode.F);
        buttons.Add(KeyCode.Z);
        buttons.Add(KeyCode.X);
        buttons.Add(KeyCode.C);
        buttons.Add(KeyCode.B);
        buttons.Add(KeyCode.G);
        buttons.Add(KeyCode.V);
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

    void resetButtons()
    {
        ButtonTimer -= Time.deltaTime;
        if(ButtonTimer <= 0)
        {
                player1HButton = buttonsp1h[Random.Range(0, buttonsp1h.Length)];
            player1JButton = buttonsp1j[Random.Range(0, buttonsp1j.Length)];
            ButtonTimer = originalButtonTimer;
        }
    }

    public void movePlayer1()
    {
        if (Input.GetKeyDown(player1HButton))
        {
            PlayerPosition = rb.transform.position;
            PlayerPosition = PlayerPosition + new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
            rb.MovePosition(PlayerPosition);
            anim.Play("Armature|Run_blocking");
            aud.Play();
        }

        if (Input.GetKeyDown(player1JButton) && grounded == true)
        {
            rb.AddForce(new Vector3(0f, force, 0f), ForceMode.Impulse);
            grounded = false;
        }
    }

    //public void Move()
    //{
    //    if (Input.GetButtonDown("P1Horizontal"))
    //    {
    //        PlayerPosition = rb.transform.position;
    //        PlayerPosition = PlayerPosition + new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
    //        rb.MovePosition(PlayerPosition);
    //        anim.Play("Armature|Run_blocking");
    //    }

    //    if (Input.GetButtonDown("P1Jump") && grounded == true)
    //    {
    //        rb.AddForce(new Vector3(0f, force, 0f), ForceMode.Impulse);
    //        grounded = false;
    //    }
    //}

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