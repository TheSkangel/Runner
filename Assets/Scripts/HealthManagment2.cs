using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagment2 : MonoBehaviour
{


    public GameObject player1;
    public GameObject obstacle;
    public int Health;
    bool playerHit;
    public Canvas ui;
    public Text KOwin;
    public Image Heart1;
    public Image Heart2;
    public Sprite Full;
    public Sprite Halve;
    public Sprite Almost;
    public Sprite Dead;



    private int damage = 1;

    void Start()
    {

        ui.GetComponent<Canvas>();
        KOwin.GetComponent<Text>();
        KOwin.enabled = !KOwin.enabled;
        playerHit = false;
        Debug.Log("False");
    }


    void FixedUpdate()
    {

        if (playerHit == true && Health > 0)
        {
            DamageTaken();
            Debug.Log("DamageTaken");
            player1.transform.position = transform.position - new Vector3(1f, 0f, 0f);
            playerHit = false;
        }

        else { KOwin.enabled = KOwin.enabled; }

    }

    void DamageTaken()
    {
        Health -= damage;
        Debug.Log("Damage");
        switch (Health)
        {
            case 2:
                Heart2.GetComponent<Image>().sprite = Halve;
                //Heart2.GetComponent<Image>().sprite = Halve;
                Debug.Log("Halve");
                break;
            case 1:
                Heart2.GetComponent<Image>().sprite = Almost;
                //Heart2.GetComponent<Image>().sprite = Almost;
                Debug.Log("Almost");
                break;
            case 0:
                Heart2.GetComponent<Image>().sprite = Dead;
                //Heart2.GetComponent<Image>().sprite = Dead;
                Debug.Log("Dead");
                break;
            default:
                Heart2.GetComponent<Image>().sprite = Full;
                //Heart2.GetComponent<Image>().sprite = Full;
                Debug.Log("Full");
                break;
        }
    }

    void OnCollisionEnter(Collision coll)
    {

        if (coll.collider.CompareTag("Obstacle"))
        {
            playerHit = true;
            Debug.Log("Hit");
        }
    }
}


