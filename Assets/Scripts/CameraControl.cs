﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	[Header("Target Players")]
	public GameObject targetPlayer1;
	public GameObject targetPlayer2;
	public GameObject targetPlayer3;
	public GameObject targetPlayer4;
	private Move player1, player2, player3, player4;

	[Header("Camera Stuff")]
	public GameObject cam1;
	public GameObject trueTarget;
	public GameObject targetZoom;

	private float desiredDistance = 3f;
	private float pitch = 0f; // controls up and down
	private float pitchMin = -10f;
	private float pitchMax = 60f;
	private float yaw = 0f; // controls side to side
	private float roll = 0f; // controls camera rotation
	[Range(1f, 15f)] public float sensitivity = 15f; // create the sensitivity of the mouse

	public PlayerInControl playerInControl;

	void Start()
	{
		trueTarget = targetPlayer1;
		playerInControl = trueTarget.GetComponent<Move>().inControl;
		cam1.SetActive(true);

		player1 = targetPlayer1.GetComponent<Move>();
		player2 = targetPlayer2.GetComponent<Move>();
		player3 = targetPlayer3.GetComponent<Move>();
		player4 = targetPlayer4.GetComponent<Move>();

		player1.isControlling = true;
	}

	void Update()
	{
		// multiplying these movements by the sensitivity which let's us control how much moving to the mouse effects the camera angle.
		pitch -= sensitivity * Input.GetAxis("Mouse Y");
		yaw += sensitivity * Input.GetAxis("Mouse X");

		// Clamp prevents a value from going below a minimum or above a maximum value.
		pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

		transform.localEulerAngles = new Vector3(pitch, yaw, roll);
		
		if (Input.GetMouseButton(1))
		{
			transform.position = targetZoom.transform.position;
		}

		/// <summary>
		/// Section handling character swapping
		/// </summary>
		if (Input.GetKeyDown("1"))
		{
			cam1.SetActive(true);
			trueTarget = targetPlayer1;
			playerInControl = trueTarget.GetComponent<Move>().inControl;

			SwapCharacters(playerInControl);
		}
		else if (Input.GetKeyDown("2"))
		{
			cam1.SetActive(true);
			trueTarget = targetPlayer2;
			playerInControl = trueTarget.GetComponent<Move>().inControl;

			SwapCharacters(playerInControl);
		}
		else if (Input.GetKeyDown("3"))
		{
			cam1.SetActive(true);
			trueTarget = targetPlayer3;
			playerInControl = trueTarget.GetComponent<Move>().inControl;

			SwapCharacters(playerInControl);
		}

		if (Input.GetKeyDown("4"))
		{
			cam1.SetActive(true);
			trueTarget = targetPlayer4;
			playerInControl = trueTarget.GetComponent<Move>().inControl;

			SwapCharacters(playerInControl);
		}
	}

	void SwapCharacters(PlayerInControl player)
	{
		switch (player)
		{
			case PlayerInControl.Ava:
				player1.isControlling = true;
				player2.isControlling = false;
				player3.isControlling = false;
				player4.isControlling = false;
				break;
			case PlayerInControl.Hazmat:
				player1.isControlling = false;
				player2.isControlling = true;
				player3.isControlling = false;
				player4.isControlling = false;
				break;
			case PlayerInControl.Rox:
				player1.isControlling = false;
				player2.isControlling = false;
				player3.isControlling = true;
				player4.isControlling = false;
				break;
			case PlayerInControl.Tempest:
				player1.isControlling = false;
				player2.isControlling = false;
				player3.isControlling = false;
				player4.isControlling = true;
				break;
		}
	}

    private void LateUpdate()
    {
        // Used to be
        // transform.position = trueTarget.transform.position - desiredDistance * transform.forward + Vector3.up * 1.5f;
        // Changed to lerp to achieve a smoother followup on the character

        // Camera's position - Start from the player's position and go backwards a distance desiredDistance from the player.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, trueTarget.transform.position - desiredDistance * transform.forward + Vector3.up * 1.5f, 0.2f);
        transform.position = smoothedPosition;
    }
}