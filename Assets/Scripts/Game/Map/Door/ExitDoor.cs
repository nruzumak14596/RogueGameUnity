using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: В будущем сделать интерфейс двери
public class ExitDoor : MonoBehaviour
{
    public DungeonRoom nextRoom;
    public Vector3 exitPosition;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.gameManager.ChangeRoom(nextRoom);
        if (nextRoom == null)
            nextRoom = GameManager.gameManager.CurrentRoom;

        Player.CurrentPlayer.transform.position = GameManager.gameManager.CurrentRoom.StartDoor.GetComponent<StartDoor>().exitPosition;
    }
}
