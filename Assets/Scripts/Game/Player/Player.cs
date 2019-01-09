using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDestroyble
{
    public static Player CurrentPlayer { get; set; }

    public BaseMoveBehavior MoveBehavior;

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
        if (Input.anyKeyDown)
            CheckDircetion();
    }

    private void CheckDircetion()
    {
        Vector3 nextPosition = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.D))
            nextPosition = new Vector3(1, 0);
        if (Input.GetKeyDown(KeyCode.A))
            nextPosition = new Vector3(-1, 0);
        if (Input.GetKeyDown(KeyCode.S))
            nextPosition = new Vector3(0, -1);
        if (Input.GetKeyDown(KeyCode.W))
            nextPosition = new Vector3(0, 1);

        if (nextPosition != Vector3.zero)
            MoveBehavior.Move(nextPosition);
    }
}
