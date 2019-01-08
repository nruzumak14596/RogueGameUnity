using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public List<GameObject> MapObject { get; set; } = new List<GameObject>();
    public GameObject StartDoor { get; set; }
    public GameObject ExitDoor { get; set; }
    public GameObject wallParent;
    public GameObject floorParent;
    public GameObject doorParent;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
