using UnityEngine;

public class Fish : Movable
{
    [SerializeField]
    private GameManager.Color color;

    private void Start()
    {
        GameManager.allFish.Add(this);
        Dice.onRollDelegate += Move;

        int numCheckpoints = GameManager.checkpoints.Count;
        checkpointIndex = Mathf.FloorToInt(numCheckpoints / 2);
        GameManager.checkpoints[checkpointIndex].AddMovable(this);
    }

    void Move(GameManager.Color diceColor)
    {
        if (diceColor != color) return;

        checkpointIndex++;
        GameManager.checkpoints[checkpointIndex].AddMovable(this);

        if (checkpointIndex == GameManager.checkpoints.Count - 1)
        {
            Dice.onRollDelegate -= Move;
        }
    }
}
