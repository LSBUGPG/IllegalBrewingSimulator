using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public int speed;
	public int sprint;
	public bool pick;
	public PickUp pickedUp = null;
	public bool drop;
	public GameObject Player;
   

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
        ArrowKeyMovement();
        UnityInputMovement();

        print(Input.GetAxis("Horizontal") + "---" + (Input.GetAxis("Vertical")));

		Player.transform.localPosition = new Vector3 (0, 0, 0);
		if (Input.GetKeyDown (KeyCode.E)) {
			if (pickedUp == true) {
				drop = true;
			} else {
				pick = true;
			}
		} else {
			drop = false;
			pick = false;
		}
	}
	//	void Update () {
			//float mouseInput = Input.GetAxis("Mouse X");
			//Vector3 lookhere = new Vector3(0,mouseInput,0);
		//	transform.Rotate(lookhere);
		//}
    void ArrowKeyMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(transform.forward * speed);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
            Player.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
            Player.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(transform.right * -speed);
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            Player.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(transform.forward * -speed);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
            Player.transform.eulerAngles = new Vector3(0, 270, 0);
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.zero;
        }
    }

    void UnityInputMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = (Vector3.forward * moveX) + (Vector3.right * moveY);

        movement.x = Mathf.Clamp(movement.x, -1f, 1f);
        movement.z = Mathf.Clamp(movement.z, -1f, 1f);

        Vector2 direction = new Vector2(movement.x, movement.z);
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.rotation = Quaternion.Euler(0.0f, -angle, 0.0f);

        rb.velocity = new Vector3(movement.x * -speed, rb.velocity.y, movement.z * -speed);
    }
}
