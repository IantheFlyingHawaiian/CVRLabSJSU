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
    public int spawnCount = 0;
    public float spawnQueueCount = 0;
    public int spawnNumberPerPress = 50;
    public float heatScalar = 400.0f;

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
        int min = 0;
        int max = 100;
        var thrust = Random.Range(1.0f, 4.0f);
        Vector3 randomVector = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));

        if (spawnQueueCount > 0)
        {
            var obj = Instantiate(element, transform.position + randomVector * 2.0f, transform.rotation);
            var obj2 = Instantiate(element, transform.position + randomVector * 2.0f, transform.rotation);
            obj.GetComponent<Rigidbody>().AddForce(transform.forward + randomVector * heatScalar * thrust);
            spawnQueueCount -=2;
            spawnCount += 2;
        }
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

                spawnQueueCount = spawnQueueCount + spawnNumberPerPress;
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

