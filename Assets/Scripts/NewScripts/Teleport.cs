using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject ui;
    public GameObject objToTP;
    public Transform tpLoc;

    // 1
    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {
        ui.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        ui.SetActive(true);
        /*if((other.gameObject.tag == "Player"))
            {
                // 2
               // if (Controller.GetHairTriggerDown())
              //  {
               //     Debug.Log(gameObject.name + " Trigger Press to Teleport");
               //     objToTP.transform.position = tpLoc.transform.position;
            //}
                Debug.Log(gameObject.name + " Inside Teleport Range");
            objToTP.transform.position = tpLoc.transform.position;
        }

        // 2
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press in Teleport");
            // 3
            if (Controller.GetHairTriggerUp())
            {
                Debug.Log(gameObject.name + " Trigger Release in Teleport");
                objToTP.transform.position = tpLoc.transform.position;
            }
        }*/
        if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand")
        {
            objToTP.transform.position = tpLoc.transform.position;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        ui.SetActive(false);
    }
}
