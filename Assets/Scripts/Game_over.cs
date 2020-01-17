using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_over : MonoBehaviour {

    private new AudioSource audio;
    public GameObject objectToDisable;
    public GameObject objectToTransform;
    Vector3 tempPos;

    private void Start()
    {
        tempPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Players"));
        audio.mute = true;
        Time.timeScale = 0;
        Application.LoadLevelAdditive(3);
        objectToDisable.SetActive(false);
        tempPos.x = 701;
        tempPos.y = 650;
        objectToTransform.transform.position = tempPos;
    }
}
