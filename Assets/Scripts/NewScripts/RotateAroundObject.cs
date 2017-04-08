using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour {

    private GameObject electron;

    public GameObject electronPrefab;
    //public Transform center;
    public Vector3 axis = new Vector3(10, 54, -12);
    public Vector3 desiredPosition;
    public float radius = 50.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 280.0f;

    // Use this for initialization
    void Start () {

        electron = Instantiate(electronPrefab, transform.position + new Vector3(0,10,10), transform.rotation);
        electron.transform.localScale += new Vector3(100F, 100F, 100F);
        electron.transform.parent = GameObject.Find(this.name).transform;
        electron.transform.position = (electron.transform.position - transform.position).normalized * radius + transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        //rotate electron around object
        float step = radiusSpeed * Time.deltaTime;
        electron.transform.RotateAround(transform.position, axis, rotationSpeed * Time.deltaTime);
        desiredPosition = (electron.transform.position - transform.position).normalized * radius + transform.position;
        electron.transform.position = Vector3.MoveTowards(electron.transform.position, desiredPosition, step);
    }

}
