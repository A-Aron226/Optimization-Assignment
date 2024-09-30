using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;

	IA_PlayerActions input;
	int id_walk = Animator.StringToHash("IsWalking");

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");


		Move(h, v);
		Turning();
		Animating(h, v);
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		//anim.SetBool("IsWalking", walking);
		anim.SetBool(id_walk, walking);
	}

    public void OnMove()
    {
        //movement = movement.normalized * speed * Time.deltaTime;
        //playerRigidbody.MovePosition(transform.position + movement);

        /*input.Movement.Move.performed += ctx =>
		{
			var rawInput = input.Movement.Move.ReadValue<Vector2>();
			movement = movement.normalized * speed * Time.deltaTime;
		};

		input.Movement.Move.canceled += ctx => { movement = Vector3.zero; };*/

        Debug.Log("New Input detected");
    }
}
