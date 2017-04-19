using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TensileTester : MonoBehaviour {

    // 1
    private GameObject collidingObject;

    private GameObject testingObject;

    //lever that triggers the testing
    public GameObject lever;

    public GameObject graph;

    //
    private bool materialGrabbed;

    // Use this for initialization
    void Start () {
        materialGrabbed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(materialGrabbed == true)
        {
            if (testingObject != null)
            {
                //Keeps the Testing Object placed in the Grabber
                testingObject.transform.position = this.transform.position;
                testingObject.transform.position = testingObject.transform.position + Vector3.up * 2.8f;
                
            }
        }

        //check if lever has been pressed and if so what direction
        if (lever.GetComponent<LeverPressed>().grabberMovingUp)
        {
            StartCoroutine(ScaleOverTime(10.0f));
            //start graphing
            GameObject graph = Instantiate(Resources.Load("LineGraph", typeof(GameObject))) as GameObject;
        }
	}

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2 Bind to collidingObject
        if(col.gameObject.tag == "material")
        {
            if (!materialGrabbed)
            {
                collidingObject = col.gameObject;
                //collidingObject.transform.parent = this.transform;
                //collidingObject.transform.localPosition = Vector3.zero;
                materialGrabbed = true;
                Destroy(collidingObject);
                testingObject = Instantiate(Resources.Load("materialBarT", typeof(GameObject))) as GameObject;
                testingObject.transform.parent = this.transform;
                testingObject.transform.rotation = Quaternion.Euler(-90, 180, 0);
                testingObject.transform.position = this.transform.position;
                testingObject.transform.position = testingObject.transform.position + Vector3.up * 2.8f;
                Debug.Log("Material Mounted");
            }
        }
        
    }

    // 1 When the trigger collider enters another, this sets up the other collider as a potential grab target.
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // 2 Similar to section one (// 1), but different because it ensures that the target is set when the player holds a controller over an object for a while. Without this, the collision may fail or become buggy.
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3 When the collider exits an object, abandoning an ungrabbed target, this code removes its target by setting it to null.
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    IEnumerator ScaleOverTime(float time)
    {
        if (testingObject != null)
        {
            Vector3 originalScale = testingObject.transform.localScale;
            Vector3 destinationScale = new Vector3(.05f, 1.0f, 3.4f);

            float currentTime = 0.0f;

            do
            {
                testingObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
                currentTime += Time.deltaTime;
                yield return null;
            } while (currentTime <= time);
        }

        
    }
}
