using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrapePress : MonoBehaviour {

	public PlayerController pC;
	public GameObject GrapeSquished;
	public Text GrapepressTimer;
	public int TimeRemaining = 30;
    public coolDown timer;

	GameObject touchingGrape = null;

	// Use this for initialization
	void Start () {
		pC = GameObject.Find ("PlayerMove").GetComponent<PlayerController> ();
		GrapeSquished = (GameObject)Resources.Load ("Grape_Squished", typeof(GameObject));
	}

	// Update is called once per frame
	void Update () {
		//GrapepressTimer.text = "Timer: " + TimeRemaining;
        if (touchingGrape != null)
        {
            timer.operating = Input.GetKey(KeyCode.JoystickButton5);
            if (timer.IsFinished())
            {
                print("Done");
                Destroy(touchingGrape);
                touchingGrape = null;
                GameObject Spawn;
                Spawn = Instantiate(GrapeSquished);
                Spawn.transform.parent = transform;
                Spawn.transform.localPosition = new Vector3(0, 0.5f, 0);
                timer.Reset();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grape")
        {
            touchingGrape = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grape")
        {
            touchingGrape = null;
        }
    }
    /*
    IEnumerator Blend () {
		GrapepressTimer.enabled = true;
		print ("Cooking");
		for (int i = 0; i < TimeRemaining; i++)
		{
			yield return new WaitForSeconds (1.0f); // change number for cook time
			TimeRemaining --;
			if (TimeRemaining == 0) {
				break;
			}
			//print("...");
		}
		//print ("Done");
		yield return null;
		GameObject Spawn;
		Spawn = Instantiate(GrapeSquished);
		Spawn.transform.parent = transform;
		Spawn.transform.localPosition = new Vector3 (0, 0.5f, 0);
		one = false;
	}
    */
}
