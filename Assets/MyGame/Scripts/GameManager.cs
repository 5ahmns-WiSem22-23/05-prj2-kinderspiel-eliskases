using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameMode
    {
        Fish,
        Boat
    }
    public static GameMode gameMode { get; set; }

    public enum Color
    {
        Red,
        Green,
        Yellow,
        Blue,
        Pink,
        Orange
    }

    public static List<Checkpoint> checkpoints;
    public static int numCaught;
    public static int numSafe;

    public static List<Color> caughtColors;
    public static List<Color> safeColors;

    public delegate void OnGameEnded(string message);
    public static OnGameEnded gameEndedDelegate;

    private void Awake()
    {
        checkpoints = new List<Checkpoint>();
        caughtColors = new List<Color>();
        safeColors = new List<Color>();

        numCaught = 0;
        numSafe = 0;

        for (int i = 0; i < 11; i++)
        {
            Checkpoint cp = new Checkpoint(i - 5, i);
            checkpoints.Add(cp);
        }
    }


    public static void CheckIfGameEnded()
    {
        if (numCaught + numSafe < 4) return;
        EndGame();
    }

    static void EndGame()
    {
        if (numCaught == 2) Draw();
        else if (gameMode == GameMode.Fish && numCaught < 2 || gameMode == GameMode.Boat && numCaught > 2) Win();
        else Lost();
    }

    static void Win()
    {
        string message = "Du hast gewonnen!";
        gameEndedDelegate?.Invoke(message);
    }

    static void Lost()
    {
        string message = "Du hast verloren!";
        gameEndedDelegate?.Invoke(message);
    }

    static void Draw()
    {
        string message = "Unentschieden!";
        gameEndedDelegate?.Invoke(message);
    }


}