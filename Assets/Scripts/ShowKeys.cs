using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowKeys : MonoBehaviour {

    public Canvas ui;
    public PlayerMovement plaMov1;
    public PlayerMovement2 plaMov2;
    public Text plaOneH;
    public Text plaOneJ;
    public Text plaTwoH;
    public Text plaTwoJ;
    public string keycode;


	void Start () {
        ui.GetComponent<Canvas>();
        plaMov1 = GameObject.Find("Player").GetComponent<PlayerMovement>();
        plaMov2 = GameObject.Find("Player2").GetComponent<PlayerMovement2>();
    }
	

	void Update () {

       // keycode = plaMov1.player1HButton.ToString;

    }
}
