using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Rigidbody physics;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        physics.MovePosition(
            physics.transform.position +
            physics.transform.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime +
            physics.transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

    }
}
