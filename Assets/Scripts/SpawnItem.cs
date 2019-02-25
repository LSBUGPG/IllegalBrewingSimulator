using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
	public Pickable itemPrefab;
	public bool spawnOnStart;
	Worktop worktop;

	void Awake()
	{
		worktop = GetComponent<Worktop>();
	}

	void Start()
	{
		if (spawnOnStart)
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		Pickable pickup = Instantiate(itemPrefab, transform.position, transform.rotation);
		pickup.creator = this;
		worktop.AddItem(pickup);
	}
}
