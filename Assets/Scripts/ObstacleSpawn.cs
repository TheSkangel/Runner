using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

    public GameObject Obstacle;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Obstacle, new Vector3(i-3 * 6.0f, 0.01f, -2.5f), Quaternion.identity);
            Instantiate(Obstacle, new Vector3(i-3 * 6.0f, 0.01f, 2.5f), Quaternion.identity);
        }
    }
	

	void Update () {
		
	}
}
