using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDestroyble
{
    public static Player CurrentPlayer { get; set; }

    public int MaximumHealthPoint { get; set; }
    public int CurrentHealthPoint { get; set; }
    public int Armor { get; set; }
    public float DodgeChance { get; set; }
    public bool LifeStatus { get; set; }

    void Start ()
    {
        if (CurrentPlayer == null)
            CurrentPlayer = this;
	}
	
	void Update ()
    {
		
	}
}
