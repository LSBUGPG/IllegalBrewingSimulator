using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject light;
    bool one;
    bool click;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.L) && one == false && click == false)
        {
            light.SetActive(false);
            one = true;
            click = true;
        }
        if (Input.GetKeyDown(KeyCode.L) && one == true && click == false)
        {
            light.SetActive(true);
            one = false;
            click = true;         
        }
        click = false;
    }
}

