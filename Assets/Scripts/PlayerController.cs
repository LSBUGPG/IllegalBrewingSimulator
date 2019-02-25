using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	public int speed;
	public int sprint;
	public bool pick;
	public PickUp pickedUp = null;
	public bool drop;
	public GameObject Player;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		UnityInputMovement();

		if (Input.GetKeyDown(KeyCode.E))
		{
			if (pickedUp == true)
			{
				drop = true;
			}
			else
			{
				pick = true;
			}
		}
		else
		{
			drop = false;
			pick = false;
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
}
