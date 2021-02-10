using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int sunCost = 100;

    public int GetCost() { return sunCost; }
}
