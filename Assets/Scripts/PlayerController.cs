using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Transform hand;
	public int speed;
	public int sprint;
	Pickable pickedUp = null;
	Worktop touching = null;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		UnityInputMovement();

		if (Input.GetButtonDown("Pickup"))
		{
			if (pickedUp != null)
			{
				if (touching != null)
				{
					touching.AddItem(pickedUp);
				}
				else
				{
					pickedUp.Drop();
				}
				pickedUp = null;
			}
			else if (touching != null)
			{
				pickedUp = touching.Take();
				if (pickedUp != null)
				{
					pickedUp.Attach(hand);
				}
			}
		}
	}

	void UnityInputMovement()
	{
		Vector3 forward = Vector3.forward;
		Vector3 right = Vector3.right;

		Camera camera = Camera.main;
		if (camera != null)
		{
			forward = Vector3.Cross(camera.transform.right, Vector3.up).normalized;
			right = Vector3.Cross(Vector3.up, forward).normalized;
		}

		float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis("Vertical");

		Vector3 movement = (forward * moveY) + (right * moveX);
		Vector2 direction = new Vector2(movement.x, movement.z);
		if (direction.SqrMagnitude() > 0.0f)
		{
			float angle = Vector2.SignedAngle(Vector2.right, direction);
			transform.rotation = Quaternion.Euler(0.0f, 180f - angle, 0.0f);
		}

		rb.velocity = movement * (float)speed;
	}

	void OnTriggerEnter(Collider other)
	{
		Worktop worktop = other.GetComponent<Worktop>();
		if (worktop != null)
		{
			touching = worktop;
		}
	}

	void OnTriggerExit(Collider other)
	{
		Worktop worktop = other.GetComponent<Worktop>();
		if (worktop != null && touching == worktop)
		{
			touching = null;
		}
	}
}
