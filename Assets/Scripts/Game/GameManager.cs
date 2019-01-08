using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<DungeonRoom> DungeonRooms { get; set; } = new List<DungeonRoom>();
    [SerializeField]
    private GameObject playerPrefab;
    public MapGenerator MapGenerator;
    public DungeonRoom CurrentRoom { get; set; }
    public static GameManager gameManager;

    void Start ()
    {
        Init();

        //TODO: Обрезку экрана закинуть на специальный эвент
        Camera.main.pixelRect = new Rect((Screen.width - Screen.height) / 2, 0, Screen.height, Screen.height);
    }

    private void Awake()
    {
        gameManager = this;
    }

    private void Init()
    {
        var firstRoom = MapGenerator.CreateDungeon(DungeonRooms.Count);
        firstRoom.StartDoor.GetComponent<Collider2D>().isTrigger = false;
        DungeonRooms.Add(firstRoom);
        CurrentRoom = firstRoom;

        Player.CurrentPlayer = Instantiate(playerPrefab).GetComponent<Player>();
        Player.CurrentPlayer.transform.position = firstRoom.StartDoor.GetComponent<StartDoor>().exitPosition;
    }

    public void ChangeRoom(DungeonRoom newRoom = null)
    {
        CurrentRoom.Hide();

        if (newRoom == null)
        {
            newRoom = MapGenerator.CreateDungeon(DungeonRooms.Count);
            DungeonRooms.Add(newRoom);
            newRoom.StartDoor.GetComponent<StartDoor>().previewRoom = CurrentRoom;
        }
        else
            newRoom.Show();

        CurrentRoom = newRoom;
    }

	void Update ()
    {
        
    }
}
