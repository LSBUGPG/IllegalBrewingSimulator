using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Camera [] cameras = FindObjectsOfType<Camera>();
        foreach (Camera camera in cameras)
        {
            if (camera.enabled)
            {
                transform.LookAt(camera.transform);
                transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                break;
            }
        }
    }
}
