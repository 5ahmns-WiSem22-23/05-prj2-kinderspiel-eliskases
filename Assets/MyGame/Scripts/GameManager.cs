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

    public static List<Checkpoint> checkpoints = new List<Checkpoint>();

    private void Start()
    {
        for(int i = -5; i < 5; i++)
        {
            Checkpoint cp = new Checkpoint(i);
            checkpoints.Add(cp);
        }
    }
}