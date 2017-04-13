using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimation : MonoBehaviour
{

    public void pressLever()
    {
        GetComponent<Animation>().Play();
        Debug.Log("PRESS BUTTON");
    }
}
