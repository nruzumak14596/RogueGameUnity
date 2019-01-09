using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    public GameObject EnemyPrefab;
    public BaseMoveBehavior MoveBehavior;

    public int MaximumHealthPoint { get; set; } = 0;
    public int CurrentHealthPoint { get; set; } = 0;
    public int Armor { get; set; } = 0;
    public float DodgeChance { get; set; } = 0;
    public bool LifeStatus { get; set; } = false;
    public string Rase { get; set; } = "";
    public int Type { get; set; } = 0;

    void Start () {
		
	}
	
	void Update () {
		
	}
}
