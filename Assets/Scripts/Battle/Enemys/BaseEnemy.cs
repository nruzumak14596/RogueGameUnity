using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    public GameObject EnemyPrefab { get; set; }

    public int MaximumHealthPoint { get; set; }
    public int CurrentHealthPoint { get; set; }
    public int Armor { get; set; }
    public float DodgeChance { get; set; }
    public bool LifeStatus { get; set; }
    public string Rase { get; set; }
    public int Type { get; set; }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
