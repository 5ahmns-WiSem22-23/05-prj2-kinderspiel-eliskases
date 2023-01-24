using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    public static int numCaught = 0; 

    private void Awake()
    {
        for(int i = 0; i < 10; i++)
        {
            Checkpoint cp = new Checkpoint(i - 5, i);
            checkpoints.Add(cp);
        }
    }
}