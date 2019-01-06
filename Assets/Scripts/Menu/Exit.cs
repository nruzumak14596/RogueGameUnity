using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

	void Start ()
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ExitGame);
	}
	
	void Update ()
    {
		
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
