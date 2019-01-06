using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject tilePrefab;
    public int maxWidth;
    public int maxHeight;

    public int minWidth;
    public int minHeight;

    void Start ()
    {
        CreateMap();

       
    }
	
	void Update ()
    {
	}

    private void CreateMap()
    {
        var _width = Random.Range(minWidth, maxWidth);
        var _height = Random.Range(minHeight, maxHeight);

        Debug.Log("wdith= " + _width + " height= " + _height);
        for (var i = 1; i <= _width; i++)
            for (var j = 1; j <= _height; j++)
            {
                var _tile = Instantiate(tilePrefab);
                _tile.transform.position = new Vector3(i, j, 0);

                if (i == 1 || j == 1 || i == _width || j == _height)
                    _tile.GetComponent<SpriteRenderer>().color = Color.black;
                else
                    _tile.GetComponent<SpriteRenderer>().color = new Color(
                    Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            }
    }
}
