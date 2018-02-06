using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayer : MonoBehaviour {

	public SteamVR_TrackedObject hmd;
	public SteamVR_TrackedObject controllerLeft;
	public SteamVR_TrackedObject controllerRight;
	public Transform head;
	public HandController handLeft;
	public HandController handRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void FixedUpdate()
	{
		//get movements for each object and update them
		copyTransform(hmd.transform, head);
		copyTransform(controllerLeft.transform, handLeft.transform);
		copyTransform(controllerRight.transform, handRight.transform);
		
		handleControllerInputs();
		
		
	}
	private void copyTransform(Transform from, Transform to)
	{
		to.position = from.position;
		to.rotation = from.rotation;
	}
	private void handleControllerInputs()
	{
		int indexLeft = (int)controllerLeft.index;
		int indexRight = (int)controllerRight.index;

		handLeft.controllerVelocity = getControllerVelocity(indexLeft);
		handRight.controllerVelocity = getControllerVelocity(indexRight);
		handLeft.controllerAngularVelocity = getControllerAngularVelocity(indexLeft);
		handRight.controllerAngularVelocity = getControllerAngularVelocity(indexRight);
		
		float triggerLeft = getTrigger(indexLeft);
		float triggerRight = getTrigger(indexRight);

		handLeft.squeeze(triggerLeft);
		handRight.squeeze(triggerRight);

	}
	private float getTrigger(int controllerIndex)
	{
		return controllerIndex >= 0 ? SteamVR_Controller.Input(controllerIndex).GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).magnitude : 0.0f;
	}

	private Vector3 getControllerVelocity(int controllerIndex)
	{
		return controllerIndex >= 0 ? SteamVR_Controller.Input(controllerIndex).velocity : Vector3.zero;
	}

	private Vector3 getControllerAngularVelocity(int controllerIndex)
	{
		return controllerIndex >= 0 ? SteamVR_Controller.Input(controllerIndex).angularVelocity : Vector3.zero;
	}



}
