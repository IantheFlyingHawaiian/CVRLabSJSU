using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TensileTester : MonoBehaviour {

    // 1
    private GameObject collidingObject;

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
            collidingObject.transform.localPosition = Vector3.zero;
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
            collidingObject = col.gameObject;
            collidingObject.transform.parent = this.transform;
            collidingObject.transform.localPosition = Vector3.zero;
            materialGrabbed = true;
            Debug.Log("Material Mounted");
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
}
