using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapCamScript : MonoBehaviour {


    Vector3 constantPosition;
    Quaternion constantRotation;

	// Use this for initialization
	void Start () {
        constantPosition = new Vector3(0, 80, 0);
        constantRotation = new Quaternion(90, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Updating values...");
        transform.position = constantPosition;
        transform.rotation = constantRotation;
	}
}
