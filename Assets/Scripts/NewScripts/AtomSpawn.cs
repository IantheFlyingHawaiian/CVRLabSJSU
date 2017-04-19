using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomSpawn : MonoBehaviour
{
    public string prefab;
    private GameObject element;
    private bool elementSpawned = false;
    private float respawnTime = 30.0f;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "leftHand" || other.gameObject.tag == "rightHand")
            // 2
            if (!elementSpawned)
            {
                Debug.Log("Element spawn" + prefab);
                element = (GameObject) Instantiate(Resources.Load(prefab));
                element.transform.position = this.transform.position + (Vector3.forward * 3.0f);
                elementSpawned = true;
                StartCoroutine("Countdown", 10);
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
