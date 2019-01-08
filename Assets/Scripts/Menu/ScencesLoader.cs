using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScencesLoader : MonoBehaviour {


    public string scenesName;
	// Use this for initialization
	void Start ()
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void LoadScene()
    {
        SceneManager.LoadScene(scenesName);
    }
}
