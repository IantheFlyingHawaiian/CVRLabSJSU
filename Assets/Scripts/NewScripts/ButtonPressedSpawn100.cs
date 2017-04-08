using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressedSpawn100 : MonoBehaviour
{

    //public GameObject button;
    public AudioSource buttonSound;
    public ButtonAnimation pressButtonAnimation;

    //Molecule to spawmn
    public GameObject element;
    private bool elementSpawned = false;
    private float respawnTime = 1.5f;

    public float spawnNumber = 200;

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
        buttonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand")
        {
            Debug.Log("Button Pressed!");
            buttonSound.Play();
            buttonSound.Play(44100);
            pressButtonAnimation.pressButton();

            //Spawn Molecule
            if (!elementSpawned)
            {
                int min = 0;
                int max = 100;
                Vector3 randomVector = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));

                for (int i = 0; i < spawnNumber; i++)
                {
                    Instantiate(element, transform.position + randomVector * 2.0f, transform.rotation);
                }
                elementSpawned = true;
                StartCoroutine("Countdown", respawnTime);
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
        }
        elementSpawned = false;
        Debug.Log("CountDown Complete: Can Spawn Element again");
    }
}

