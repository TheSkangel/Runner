using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour{

    public Rigidbody rb;
    public Animator anim;
    public float speed;
    public float force;
    public KeyCode player2HButton;
    public KeyCode player2JButton;

    private Vector3 PlayerPosition;
    private KeyCode[] buttonsp2h;
    private KeyCode[] buttonsp2j;

    bool grounded = false;
    bool playerHit = false;

    public float timer; // set how long you want to slow down your player;
    private float originalTime;
    private float originalSpeed;

    public float ButtonTimer;
    private float originalButtonTimer;

    void Awake()
    {
        anim.GetComponent<Animator>();
        rb.GetComponent<Rigidbody>();
        originalSpeed = speed;
        originalTime = timer;
        buttonsp2j = new KeyCode[] { KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.Semicolon, };
        buttonsp2h = new KeyCode[] { KeyCode.J, KeyCode.K, KeyCode.H, KeyCode.L, KeyCode.N, KeyCode.M };
        originalButtonTimer = ButtonTimer;
    }

    void Start()
    {
        player2HButton = buttonsp2h[Random.Range(0, buttonsp2h.Length)];
        player2JButton = buttonsp2j[Random.Range(0, buttonsp2j.Length)];
    }

    void Update()
    {
        resetButtons();
    }

    void FixedUpdate()
    {

        movePlayer1();
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

    void resetButtons()
    {
        ButtonTimer -= Time.deltaTime;
        if (ButtonTimer <= 0)
        {
            player2HButton = buttonsp2h[Random.Range(0, buttonsp2h.Length)];
            player2JButton = buttonsp2j[Random.Range(0, buttonsp2j.Length)];
            ButtonTimer = originalButtonTimer;
        }
    }

    public void movePlayer1()
    {
        if (Input.GetKeyDown(player2HButton))
        {
            PlayerPosition = rb.transform.position;
            PlayerPosition = PlayerPosition + new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
            rb.MovePosition(PlayerPosition);
            anim.Play("Armature|Run_blocking");
        }

        if (Input.GetKeyDown(player2JButton) && grounded == true)
        {
            rb.AddForce(new Vector3(0f, force, 0f), ForceMode.Impulse);
            grounded = false;
        }
    }

    //public void Move()
    //{
    //    if (Input.GetButtonDown("P2Horizontal"))
    //    {
    //        PlayerPosition = rb.transform.position;
    //        PlayerPosition = PlayerPosition + new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
    //        rb.MovePosition(PlayerPosition);
    //        anim.Play("Armature|Run_blocking");
    //    }

    //    if (Input.GetButtonDown("P2Jump") && grounded == true)
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