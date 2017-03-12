using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startRunning : MonoBehaviour {

	Animator anim;

	void Start ()
	{
		anim.GetComponent<Animator> ();
	}

	void Update ()
	{
		float move = Input.GetAxis("Vertical");
		anim.SetFloat ("Speed", move);
	}

}
