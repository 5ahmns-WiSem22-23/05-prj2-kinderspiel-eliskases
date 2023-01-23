using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private void Start()
    {
        Dice.onRollDegate += Move;
    }

    void Move(GameManager.Color diceColor)
    {
        if (diceColor != GameManager.Color.Red && diceColor != GameManager.Color.Green)
            return;

        float posX = transform.position.x + 1;
        float posY = transform.position.y;

        transform.position = new Vector2(posX, posY);
    }
}
