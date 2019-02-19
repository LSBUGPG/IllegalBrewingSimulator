using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera2 : MonoBehaviour
{

    public GameObject Camera;

    public GameObject ui;
    bool idk = false;

    private void Start()
    {
        if (idk == true)
        {
            StartCoroutine(rotate());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Camera is on CHEEEESE");
            StartCoroutine(rotate());
            idk = true;
        }

    }

    IEnumerator rotate()
    {
        yield return new WaitForSeconds(0.0f);
        print("Rotating wooooo");
        //ui.transform.Rotate(0.0f, -90f, 0.0f * Time.deltaTime);
        idk = false;
    }
}
