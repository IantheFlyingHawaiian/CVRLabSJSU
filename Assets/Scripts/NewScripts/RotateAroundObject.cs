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

    //electron shells values 1s, 
    public int firstShellElecCount = 2;
    public int secondShellElecCount = 4;
    public int thirdShellElecCount = 0;
    public int fourthShellElecCount = 0;
    public int fifthShellElecCount = 0;
    public int sixthShellElecCount = 0;
    public int seventhShellElecCount = 0;

    public const int FIRST_SHELL = 2;
    public const int SECOND_SHELL = 8;
    public const int THIRD_SHELL = 18;
    public const int FOURTH_SHELL = 32;
    public const int FIFTH_SHELL = 32;
    public const int SIXTH_SHELL = 18;
    public const int SEVENTH_SHELL = 9;

    //radial distance
    public float radialDistance = 100f;

    //electron array
    ArrayList electrons;


    // Use this for initialization
    void Start () {

        electrons = new ArrayList();

        /*Instanitate each electron at each shell

        //The transform.position - new Vector3(-10f, 10f) centers the electron around the atom
        electron = Instantiate(electronPrefab, transform.position - new Vector3(-10f,10f), transform.rotation);
        electron.transform.localScale += new Vector3(100F, 100F, 100F);
        electron.transform.parent = GameObject.Find(this.name).transform;
        electron.transform.position = (electron.transform.position - transform.position).normalized * radius + transform.position;
        */

        //Generate First Shell
        for(int i =0; i < firstShellElecCount; i++)
        {
            int val = i + 1;
            if (i == 0)
            {
                electron = Instantiate(electronPrefab, transform.position - new Vector3(-10f * val, 10f * val), transform.rotation);
                electron.transform.localScale += new Vector3(100F, 100F, 100F);
                electron.transform.parent = GameObject.Find(this.name).transform;
                electron.transform.position = (electron.transform.position - transform.position).normalized * radius + transform.position;
                electrons.Add(electron);
            }
            else
            {
                Quaternion rotation = Quaternion.identity;
                rotation.eulerAngles = new Vector3(0, 90, 0);
                transform.rotation = rotation;
                electron = Instantiate(electronPrefab, transform.position - new Vector3(-10f, 10f), transform.rotation);
                electron.transform.localScale += new Vector3(100F, 100F, 100F);
                electron.transform.parent = GameObject.Find(this.name).transform;
                electron.transform.position = (electron.transform.position - transform.position).normalized * radius + transform.position;
                electrons.Add(electron);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        //rotate electron around object
        foreach(GameObject electron in electrons)
        {
            float step = radiusSpeed * Time.deltaTime;
            electron.transform.RotateAround(transform.position, axis, rotationSpeed * Time.deltaTime);
            desiredPosition = (electron.transform.position - transform.position).normalized * radius + transform.position;
            electron.transform.position = Vector3.MoveTowards(electron.transform.position, desiredPosition, step);
        }
    }

}
