using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowScript : MonoBehaviour {
    public GameObject GrapePrefab;
    public Image GrapePressUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GrapePressUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        //look at tag "Cam" ~ Swap active cam's tag to "Cam"
	}
}
