﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour
{
	internal SpawnItem creator;
	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public Pickable Attach(Transform location)
	{
		rb.useGravity = false;
		rb.isKinematic = true;
		transform.position = location.transform.position;
		transform.rotation = location.transform.rotation;
		transform.SetParent(location.transform, true);
		return this;
	}

	public Pickable Drop()
	{
		rb.useGravity = true;
		rb.isKinematic = false;
		transform.parent = null;
		return null;
	}

	public void Respawn()
	{
		if (creator.spawnOnStart)
		{
			creator.Spawn();
		}
		Destroy(gameObject);
	}

	public bool Attached()
	{
		return transform.parent != null;
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Floor"))
        {
			Respawn();
        }
	}
}