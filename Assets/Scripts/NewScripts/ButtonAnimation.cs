using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour {

	public void pressButton()
    {
        GetComponent<Animation>().Play();
        Debug.Log("PRESS BUTTON");
    }
}
