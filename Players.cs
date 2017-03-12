using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public AudioClip[] audioClip;

	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "jump") {
			manager.jump = 1;
			PlaySound (0);
		}

		if (other.transform.tag == "Finish")
		{
			PlaySound (1);
			manager.CompleteLevel ();
		}
	}
	void PlaySound(int clip)
	{
		audio.clip = audioClip [clip];
		audio.Play
	}

	// Update is called once per frame
	void Update () {
		
	}
}
