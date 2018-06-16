﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour {

	public Transform[] backgrounds; //array of the back and foregrounds to be paralaxed
	private float[] parallaxScales; //proportion of camera's movement to move the parralax by
	public float smoothing = 1f; // how smooth the paralax is going to be. set above 0

	private Transform cam; //reference to the main cameras transform
	private Vector3 previousCamPos; //the position of the camera in the previous frame

	// is called before start().
	void Awake () {
		//set up camera reference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start ()
	{
		// the previous frame had the current frame's camera position
		previousCamPos = cam.position;

		// asigning coresponding parallax scales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		for (int i = 0; i < backgrounds.Length; i++) {
			//the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			//set a target xpos which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			//create a target position witch is the background's current position with it's target x position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			//fade between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		//set the previousCamPos to the camera's position at the end of the frame.
		previousCamPos = cam.position;
	}
}
