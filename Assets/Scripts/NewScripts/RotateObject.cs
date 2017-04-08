using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // ...also rotate around the World's Y axis
        transform.Rotate(new Vector3(0,16,0) * Time.deltaTime, Space.World);

    }
}
