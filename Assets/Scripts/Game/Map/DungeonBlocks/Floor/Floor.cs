using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public List<Sprite> floorSprites = new List<Sprite>();
	void Start ()
    {
        GetComponent<SpriteRenderer>().sprite = floorSprites[Random.Range(0, floorSprites.Count)];
	}

	void Update () {
		
	}
}
