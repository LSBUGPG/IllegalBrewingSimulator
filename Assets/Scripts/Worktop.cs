using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worktop : MonoBehaviour
{
	public Transform surface;
	Pickable item;

	public void AddItem(Pickable pickup)
	{
		item = pickup.Attach(surface);
	}

	public Pickable Take()
	{
		Pickable pickup = item;
		item = null;
		return pickup;
	}
}
