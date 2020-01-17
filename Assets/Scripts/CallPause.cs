using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPause : MonoBehaviour {

    void Start () {
		
	}
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Application.LoadLevelAdditive(2);
        }
	}
}
