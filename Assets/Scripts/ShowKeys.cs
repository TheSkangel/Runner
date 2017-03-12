using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowKeys : MonoBehaviour
{

    public Canvas ui;
    public PlayerMovement plaMov1;
    public PlayerMovement2 plaMov2;
    public Text plaOneH;
    public Text plaOneJ;
    public Text plaTwoH;
    public Text plaTwoJ;


    void Start()
    {
        ui.GetComponent<Canvas>();
        plaMov1 = GameObject.Find("Character 1").GetComponent<PlayerMovement>();
        plaMov2 = GameObject.Find("Character 2").GetComponent<PlayerMovement2>();
    }


    void Update()
    {


        plaOneH.text = plaMov1.player1HButton.ToString();
        plaOneJ.text = plaMov1.player1JButton.ToString();
        plaTwoH.text = plaMov2.player2HButton.ToString();
        plaTwoJ.text = plaMov2.player2JButton.ToString();

    }
}
