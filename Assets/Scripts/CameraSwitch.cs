using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras = new GameObject[3];
    public GameObject ui;

    // Use this for initialization
    void Start()
    {
        switchCameras(0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("1") && cameras[0] != null)
        {
            switchCameras(0);
        }
        else if (Input.GetKeyDown("2") && cameras[1] != null)
        {
            switchCameras(1);
//            StartCoroutine(rotate());
        }
        else if (Input.GetKeyDown("3") && cameras[2] != null)
        {
            switchCameras(2);
        }
    }

    private void switchCameras(int keyNum)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != null && keyNum != i)
            {
                // turn camera off
                cameras[i].GetComponent<Camera>().enabled = false;
            }
            else
            {
                // turn camera on
                cameras[i].GetComponent<Camera>().enabled = true;
            }
        }
    }
 /*   IEnumerator rotate()
    {
        yield return new WaitForSeconds(0.0f);
        print("Rotating wooooo");
        ui.transform.Rotate(0.0f, -90f, 0.0f * Time.deltaTime);
        //idk = false;
    } */
}