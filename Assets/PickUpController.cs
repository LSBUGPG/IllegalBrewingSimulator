using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "WorkTop")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            transform.parent = other.transform;
        }
    }
}
