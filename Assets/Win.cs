using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim.GetComponent<Animator> ();
	}

	/*void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Banner")){
			Debug.Log ("touch");
			anim.Play ("win");
		}
	}*/
	void Update(){
		if (Input.GetKeyDown("C")
			anim.Play("Armature|Run_blocking",-1,0f);
			}
}
