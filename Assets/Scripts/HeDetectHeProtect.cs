using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeDetectHeProtect : MonoBehaviour {

    public Slider Detect;
    public float DRate;
    bool triggered;


	// Use this for initialization
	void Start () {
            Detect.value = 0; 
	}

	// Update is called once per frame
	void Update () {
        if (triggered == false)
        {
            Detect.value -= DRate;
        }
        triggered = false;
        if (Detect.value >= Detect.maxValue)
        {
            print("Game Over");
            SceneManager.LoadScene("GameOver");
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            Detect.value += DRate*3;
            triggered = true;
        }
    }
}
