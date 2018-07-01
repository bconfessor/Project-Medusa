using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standingStillScript : MonoBehaviour {

    Vector3 standingPosition;
	// Use this for initialization
	void Start () {
        standingPosition = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, standingPosition.y, transform.position.z);
	}
}
