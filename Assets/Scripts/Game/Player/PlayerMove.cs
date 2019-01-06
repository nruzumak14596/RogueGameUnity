using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	
	void Start ()
    {
		
	}

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
            gameObject.transform.position += new Vector3(1, 0);
        if (Input.GetKeyDown(KeyCode.A))
            gameObject.transform.position += new Vector3(-1, 0);
        if (Input.GetKeyDown(KeyCode.S))
            gameObject.transform.position += new Vector3(0, -1);
        if (Input.GetKeyDown(KeyCode.W))
            gameObject.transform.position += new Vector3(0, 1);
        //gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0);
        //gameObject.transform.position += new Vector3(0, Input.GetAxis("Vertical"));
    }
}
