using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
	public void StartGameBTN(string StartGameRace)
	{
		SceneManager.LoadScene (StartGameRace);
	}

	public void ExitButton()
	{
		Application.Quit ();
	}
}
