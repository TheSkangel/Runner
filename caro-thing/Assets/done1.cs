using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class done1 : MonoBehaviour
{
    bool finished = false;




    void OnTriggerEnter()
    {
        finished = true;
    }


    void Update()
    {
        if (finished)
        {

            SceneManager.LoadScene("Red_wins");
        }


    }

}
