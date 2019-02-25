using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Worktop))]
[RequireComponent(typeof(SpawnItem))]
public class GrapePress : MonoBehaviour
{
	public coolDown timer;
	SpawnItem squashedGrapeSpawner;
	Worktop worktop;

	void Awake()
	{
		worktop = GetComponent<Worktop>();
		squashedGrapeSpawner = GetComponent<SpawnItem>();
	}

	public void Operate(bool activate)
	{
		if (worktop.HasItem("Grape"))
		{
			timer.operating = activate;
			if (timer.IsFinished())
			{
				Pickable grape = worktop.Take();
				grape.Respawn();
				squashedGrapeSpawner.Spawn();
				timer.Reset();
			}
		}
	}
}
