using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
	public Canvas startup;

	// Use this for initialization
	void Start() {
		startup = startup.GetComponent<Canvas>();
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.L))
		{ SceneManager.LoadScene("main");
		}
	}
	public void ExitButton() {
		if (Input.GetKeyDown(KeyCode.Escape))
		{ Application.Quit ();
		}
	}
}

	