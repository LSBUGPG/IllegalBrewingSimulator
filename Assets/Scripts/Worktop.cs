using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Worktop : MonoBehaviour
{
	internal class PlaceItemEvent: UnityEvent<Pickable> {}
	public Transform surface;
	internal PlaceItemEvent onPlaceItem = new PlaceItemEvent();
	Pickable item;

	public void AddItem(Pickable pickup)
	{
		item = pickup.Attach(surface);
		onPlaceItem.Invoke(item);
	}

	public Pickable Take()
	{
		Pickable pickup = item;
		item = null;
		return pickup;
	}

	public bool HasItem(string tag)
	{
		return item != null && item.CompareTag(tag);
	}
}
