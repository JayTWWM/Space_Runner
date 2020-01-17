using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybind : MonoBehaviour {

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public GameObject forward, right, left;
    // Use this for initialization
    void Start () {
        keys.Add("forward", KeyCode.W);
        keys.Add("right", KeyCode.D);
        keys.Add("left", KeyCode.A);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
