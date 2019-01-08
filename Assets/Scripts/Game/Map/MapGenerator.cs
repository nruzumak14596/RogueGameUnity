using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation
{
    Left = 0,
    Right = 1,
    Top = 2,
    Down = 3
}

public class MapGenerator : MonoBehaviour {

    public GameObject floorPrefab;
    public GameObject startDoorPrefab;
    public GameObject exitDoorPrefab;
    public GameObject wallPrefab;

    public int maxWidth = 22;
    public int maxHeight = 22;

    public int minWidth = 12;
    public int minHeight = 12;

    private int width = 12;
    private int height = 12;

    void Start ()
    {
    }
	
	void Update ()
    {
	}

    public DungeonRoom CreateDungeon(int roomIndex)
    {
        var newRoom =new GameObject("Room " + roomIndex);
        newRoom.transform.SetParent(transform);

        var dungeonRoom = newRoom.AddComponent<DungeonRoom>();

        dungeonRoom.floorParent = new GameObject("Floors");
        dungeonRoom.floorParent.transform.SetParent(newRoom.transform);

        dungeonRoom.wallParent = new GameObject("Walls");
        dungeonRoom.wallParent.transform.SetParent(newRoom.transform);

        dungeonRoom.doorParent = new GameObject("Doors");
        dungeonRoom.doorParent.transform.SetParent(newRoom.transform);

        width = Random.Range(minWidth, maxWidth);
        height = Random.Range(minHeight, maxHeight);


        CreateDoors(dungeonRoom);
        CreateFloor(dungeonRoom);

        return dungeonRoom;
    }

    protected void CreateFloor(DungeonRoom dungeonRoom)
    {
        for (var i = 1; i <= width; i++)
            for (var j = 1; j <= height; j++)
            {
                if (dungeonRoom.ExitDoor.transform.position == new Vector3(i, j, 0) ||
                   dungeonRoom.StartDoor.transform.position == new Vector3(i, j, 0))
                   continue;

                GameObject element;
                if (i == 1 || j == 1 || i == width || j == height)
                    element = Instantiate(wallPrefab, dungeonRoom.wallParent.transform);
                else
                {
                    element = Instantiate(floorPrefab, dungeonRoom.floorParent.transform); ;
                    element.GetComponent<SpriteRenderer>().color = new Color(
                    Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                }

                element.transform.position = new Vector3(i, j, 0);
                dungeonRoom.MapObject.Add(element);
            }
    }

    protected void CreateDoors(DungeonRoom dungeonRoom)
    {
        var direction = (Orientation)Random.Range(0, 3);

        var startDoor = Instantiate(startDoorPrefab, dungeonRoom.doorParent.transform);
        startDoor.transform.position = GenerateDoorPosition(direction, 
            out startDoor.GetComponent<StartDoor>().exitPosition);

        var exitDoor = Instantiate(exitDoorPrefab, dungeonRoom.doorParent.transform);

        do
            exitDoor.transform.position = GenerateDoorPosition(direction,
                out exitDoor.GetComponent<ExitDoor>().exitPosition);
        while (startDoor.transform.position == exitDoor.transform.position);

        dungeonRoom.ExitDoor = exitDoor;
        dungeonRoom.StartDoor = startDoor;

        dungeonRoom.MapObject.Add(exitDoor);
        dungeonRoom.MapObject.Add(startDoor);
    }

    private Vector3 GenerateDoorPosition(Orientation direction, out Vector3 exitPosition)
    {
        Vector3 doorPosition = Vector3.zero;
        exitPosition = Vector3.right;
        switch (direction)
        {
            case Orientation.Top:
                doorPosition = new Vector3(Random.Range(2, width - 1), height, 0);
                exitPosition = doorPosition + Vector3.down;
                break;
            case Orientation.Down:
                doorPosition = new Vector3(Random.Range(2, width - 1), 1, 0);
                exitPosition = doorPosition + Vector3.up;
                break;
            case Orientation.Left:
                doorPosition =  new Vector3(1, Random.Range(2, height - 1), 0);
                exitPosition = doorPosition + Vector3.right;
                break;
            case Orientation.Right:
                doorPosition =  new Vector3(width, Random.Range(2, height - 1), 0);
                exitPosition = doorPosition + Vector3.left;
                break;               
        }
        return doorPosition;

        //if (Random.Range(0, 2) == 0)
        //    if (Random.Range(0, 2) == 0)
        //        return new Vector3(Random.Range(2, width - 1), 1, 0);
        //    else
        //        return new Vector3(Random.Range(2, width - 1), height, 0);
        //else
        //    if (Random.Range(0, 2) == 0)
        //        return new Vector3(1, Random.Range(2, height - 1), 0);
        //    else
        //        return new Vector3(width, Random.Range(2, height - 1), 0);
    }
}
