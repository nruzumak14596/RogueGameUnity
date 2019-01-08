using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestroyble
{
    int MaximumHealthPoint { get; set; }
    int CurrentHealthPoint { get; set; }
    int Armor { get; set; }
    float DodgeChance { get; set; }
    bool LifeStatus { get; set; }
}
