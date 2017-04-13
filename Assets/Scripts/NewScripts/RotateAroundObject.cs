using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour {

    private GameObject electron;

    public GameObject electronPrefab;
    //public Transform center;
    [SerializeField] private Vector3 axis = new Vector3(50, 54, -12);
    public Vector3 desiredPosition;
    public Vector3 desiredPosition2nd;
    public Vector3 desiredPosition3rd;
    public float radius = 50.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 400.0f;

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

    public float electronScale = 100f;

    //radial distance
    public float radialDistance = 100f;

    //electron array
    ArrayList electrons;
    //electron array second shell
    ArrayList electrons2nd;
    //electron array second shell
    ArrayList electrons3rd;


    // Use this for initialization
    void Start () {

        electrons = new ArrayList();
        electrons2nd = new ArrayList();
        electrons3rd = new ArrayList();

        /*Instanitate each electron at each shell

        //The transform.position - new Vector3(-10f, 10f) centers the electron around the atom
        electron = Instantiate(electronPrefab, transform.position - new Vector3(-10f,10f), transform.rotation);
        electron.transform.localScale += new Vector3(100F, 100F, 100F);
        electron.transform.parent = GameObject.Find(this.name).transform;
        electron.transform.position = (electron.transform.position - transform.position).normalized * radius + transform.position;
        */

        //Generate First Shell
        for (int i =0; i < firstShellElecCount; i++)
        {
  
            Quaternion rotation = Quaternion.identity;
            int eulerAngle = 90 * (i+1);
            rotation.eulerAngles = new Vector3(0, eulerAngle, 0);
            transform.rotation = rotation;
            electron = Instantiate(electronPrefab, transform.position - new Vector3(-10f, 10f), transform.rotation);
            electron.transform.localScale += new Vector3(electronScale, electronScale, electronScale);
            electron.transform.parent = GameObject.Find(this.name).transform;
            electron.transform.position = (electron.transform.position - transform.position).normalized * radius + transform.position;
            electrons.Add(electron);
        }

        //Generate Second Shell
        for (int i = 0; i < secondShellElecCount; i++)
        {

            Quaternion rotation = Quaternion.identity;
            int eulerAngle = 90 * (i+1);
            if (eulerAngle == 360) eulerAngle = 359;
            rotation.eulerAngles = new Vector3(eulerAngle, eulerAngle, 0);
            transform.rotation = rotation;
            electron = Instantiate(electronPrefab, transform.position - new Vector3(-10f, 10f), transform.rotation);
            electron.transform.localScale += new Vector3(electronScale, electronScale, electronScale);
            electron.transform.parent = GameObject.Find(this.name).transform;
            electron.transform.position = (electron.transform.position - transform.position).normalized * radius * 2.0f+ transform.position;
            electrons2nd.Add(electron);
        }

        //Generate Third Shell
        for (int i = 0; i < thirdShellElecCount; i++)
        {

            Quaternion rotation = Quaternion.identity;
            int eulerAngle = 16 * (i+1);
            
            rotation.eulerAngles = new Vector3(eulerAngle, eulerAngle, 0);
            transform.rotation = rotation;
            electron = Instantiate(electronPrefab, transform.position - new Vector3(-10f, 10f), transform.rotation);
            electron.transform.localScale += new Vector3(electronScale, electronScale, electronScale);
            electron.transform.parent = GameObject.Find(this.name).transform;
            electron.transform.position = (electron.transform.position - transform.position).normalized * radius * 3.0f + transform.position;
            electrons3rd.Add(electron);
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

        foreach(GameObject electron in electrons2nd)
        {
            float step = radiusSpeed * Time.deltaTime;
            electron.transform.RotateAround(transform.position, axis, rotationSpeed * Time.deltaTime);
            desiredPosition2nd = (electron.transform.position - transform.position).normalized * radius * 2.0f + transform.position;
            electron.transform.position = Vector3.MoveTowards(electron.transform.position, desiredPosition2nd, step);
        }

        
        foreach (GameObject electron in electrons3rd)
        {
            float step = radiusSpeed * Time.deltaTime;
            electron.transform.RotateAround(transform.position, axis, rotationSpeed * Time.deltaTime);
            electron.transform.position = Vector3.MoveTowards(electron.transform.position, desiredPosition3rd, step);
            desiredPosition3rd = (electron.transform.position - transform.position).normalized * radius * 3.0f + transform.position;
        }
    }

}
