using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Fish> allFish = new List<Fish>();

    public enum Color
    {
        Red,
        Green,
        Yellow,
        Blue,
        Pink,
        Orange
    }

    private void Start()
    {
        
    }
}
