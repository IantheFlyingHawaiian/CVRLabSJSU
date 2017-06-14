using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSlider : MonoBehaviour {

    public float red, green, blue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RedChanged(float value)
    {
        this.red = value;
        SetColor();
    }

    public void BlueChanged(float value)
    {
        this.blue = value;
        SetColor();
    }

    public void GreenChanged(float value)
    {
        this.green = value;
        SetColor();
    }

    public void SetColor()
    {
        GetComponent<Renderer>().material.color = new Color(red, green, blue);
    }
}
