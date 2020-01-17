using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour {
    public Text countText;
    private int count;

    private void Start()
    {
        count = 0;
        countText.text = "Score:-" + count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AsteroidCube")) ;
        other.gameObject.SetActive(false);
        count++;
        countText.text = "Score:-" + count.ToString();
    }
}
