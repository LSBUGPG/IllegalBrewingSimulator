using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Worktop))]
[RequireComponent(typeof(SpawnItem))]
public class Barrel : MonoBehaviour
{
	public coolDown timer;
	bool hasYeast;
	bool hasSquashedGrapes;
	SpawnItem bottleSpawner;
	Worktop worktop;

	void Start()
	{
		bottleSpawner = GetComponent<SpawnItem>();
		worktop = GetComponent<Worktop>();
		worktop.onPlaceItem.AddListener((item) => TakeItem(item));
	}

	void TakeItem(Pickable pickup)
	{
		if (pickup.CompareTag("SGrape"))
		{
			hasSquashedGrapes  = true;
		}

		if (pickup.CompareTag("Yeast"))
		{
			hasYeast = true;
		}

		if (!pickup.CompareTag("Bottle"))
		{
			worktop.Take();
			pickup.Respawn();
		}
	}
	
	public void Operate(bool activate)
	{
		if (hasYeast && hasSquashedGrapes)
		{
			timer.operating = activate;
			if (timer.IsFinished())
			{
				bottleSpawner.Spawn();
				timer.Reset();
				hasYeast = false;
				hasSquashedGrapes = false;
			}
		}
	}
}
