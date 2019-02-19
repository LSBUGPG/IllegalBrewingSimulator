using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    bool carrying;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (carrying == false)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                pickup();
                carrying = true;
            }
        }
        else if (carrying == true)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                drop();
                carrying = false;
            }
        }
    }
    void pickup()
    {
        Debug.Log("PickedUp");
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }
    void drop()
    {
        Debug.Log("Dropped");
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        //item.transform.position = guide.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grape")
        {
            item = other.gameObject;
        }
    }

}