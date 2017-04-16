using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPressed : MonoBehaviour
{

    //public GameObject button;
    public AudioSource buttonSound;
    public LeverAnimation pressLeverAnimation;

    //Molecule to spawmn
    public GameObject grabber;
    private bool grabberMoving = false;
    private bool grabberInputReady = true;
    private float respawnTime = 3f;

    private Vector3 grabberBasePosition;

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
    void Start()
    {
        grabberBasePosition = grabber.transform.position;
        buttonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabberMoving)
        {
            //Move Grabber up
            if (grabberBasePosition.y + 10 > grabber.transform.position.y)
            {
                grabber.transform.Translate(Vector3.up * Time.deltaTime);
            }
        }
        else
        {
            //Move grabber to base position
            if (grabberBasePosition.y <= grabber.transform.position.y)
            {
                //move the object down
                grabber.transform.Translate(Vector3.down * Time.deltaTime);
            }
        }
           
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand")
        {
            Debug.Log("Button Pressed!");
            buttonSound.Play();
            buttonSound.Play(44100);
            pressLeverAnimation.pressLever();

            if (grabberInputReady)
            {
                //Move Grabber Up
                if (grabberMoving)
                {
                    grabberMoving = false;
                }
                else
                {
                    grabberMoving = true;
                }

                Countdown((int)respawnTime);
            }
        }
    }


    //Allow Element to spawn after countdown
    private IEnumerator Countdown(int time)
    {
        while (time >= 0)
        {
            Debug.Log(time--);
            yield return new WaitForSeconds(1);
            grabberInputReady = false;
            
        }
        //grabberMoving = false;
        grabberInputReady = true;
        Debug.Log("CountDown Complete: Can Spawn Element again");
    }
}

