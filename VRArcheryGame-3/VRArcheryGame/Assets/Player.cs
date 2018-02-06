using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public tempBow b;
    public Transform controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        b.transform.position = controller.position;
        b.transform.rotation = controller.rotation;
	}
}
