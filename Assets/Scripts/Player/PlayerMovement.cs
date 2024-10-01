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
		//float h = Input.GetAxisRaw("Horizontal");
		//float v = Input.GetAxisRaw("Vertical");

		float h = Horizontal;
		float v = Vertical;

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

    public void OnMove() //Here in case I want to change input system back to this
    {

    }

	float Vertical //temp New input for checking if the W or S key have been pressed
	{ get
		{
			var keyboard = Keyboard.current;
			var vertical = 0;

			if (keyboard.wKey.isPressed)
			{
				vertical = 1;
			}
			else if (keyboard.sKey.isPressed)
			{
				vertical = -1;
			}

			return vertical;
		}
	}

	float Horizontal //temp New input for checking if the A or D key have been pressed
    { get
		{
			var keyboard = Keyboard.current;
			var horizontal = 0;

			if (keyboard.dKey.isPressed)
			{
				horizontal = 1;
			}
			else if (keyboard.aKey.isPressed)
			{ 
				horizontal= -1;
			}

			return horizontal;
		}
	}

}
