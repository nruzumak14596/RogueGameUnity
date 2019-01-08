using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy : IDestroyble
{
    GameObject EnemyPrefab { get; set; }
    string Rase { get; set; }
    int Type { get; set; }
}
