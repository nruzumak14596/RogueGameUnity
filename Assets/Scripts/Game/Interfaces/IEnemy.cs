using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy : IDestroyble
{
    string Rase { get; set; }
    int Type { get; set; }
}
