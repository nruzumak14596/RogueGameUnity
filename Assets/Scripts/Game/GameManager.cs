using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start ()

    {
        //TODO: Обрезку экрана закинуть на специальный эвент
        Camera.main.pixelRect = new Rect((Screen.width - Screen.height) / 2, 0, Screen.height, Screen.height);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
