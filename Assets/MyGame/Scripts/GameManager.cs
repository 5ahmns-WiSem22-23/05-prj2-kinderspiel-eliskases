using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameMode
    {
        Fish,
        Boat
    }
    private static GameMode gameMode = GameMode.Fish;

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
    public static int numSafe = 0;

    private void Awake()
    {
        for(int i = 0; i < 11; i++)
        {
            Checkpoint cp = new Checkpoint(i - 5, i);
            checkpoints.Add(cp);
        }
    }

    public static void EndGame()
    {
        if (numCaught == 2) Draw();
        else if (gameMode == GameMode.Fish && numCaught < 2 || gameMode == GameMode.Boat && numCaught > 2) Win();
        else Lost();
    }

    static void Win()
    {
        print("You Won");
    }

    static void Lost()
    {
        print("You Lost");
    }

    static void Draw()
    {
        print("Draw");
    }
}