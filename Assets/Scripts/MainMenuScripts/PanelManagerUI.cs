using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManagerUI : MonoBehaviour {


    public GameObject chaptersPanel;


	// Use this for initialization
	void Start () {
        chaptersPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleSettingsPanel()
    {

        bool active;
        active = chaptersPanel.activeSelf == true ? false : true;
        chaptersPanel.SetActive(active);
    }

    public void HideSettingsPanel()
    {
        chaptersPanel.SetActive(false);
    }

    public void LoadScene(string sceneToLoad)
    {
        Debug.Log(sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}

