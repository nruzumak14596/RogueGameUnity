using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoor : MonoBehaviour
{
    public DungeonRoom previewRoom;
    public Vector3 exitPosition;

    void Start ()
    {
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (previewRoom != null)
        {
            GameManager.gameManager.ChangeRoom(previewRoom);
            Player.CurrentPlayer.transform.position = GameManager.gameManager.CurrentRoom.ExitDoor.GetComponent<ExitDoor>().exitPosition;
        }

    }
}
