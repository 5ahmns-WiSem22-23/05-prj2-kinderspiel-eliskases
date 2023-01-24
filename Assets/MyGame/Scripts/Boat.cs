using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Movable
{
    private void Start()
    {
        Dice.onRollDelegate += Move;

        GameManager.checkpoints[checkpointIndex].AddMovable(this);
    }

    void Move(GameManager.Color diceColor)
    {
        if (diceColor != GameManager.Color.Red && diceColor != GameManager.Color.Green)
            return;

        checkpointIndex++;
        GameManager.checkpoints[checkpointIndex].AddMovable(this);

        if(checkpointIndex == GameManager.checkpoints.Count - 1)
        {
            Dice.onRollDelegate -= Move;
        }
    }
}
