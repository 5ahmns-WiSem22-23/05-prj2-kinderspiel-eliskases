using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField]
    private GameManager.Color color;

    int positionIndex = 0;

    private void Start()
    {
        Dice.onRollDegate += Move;
    }

    void Move(GameManager.Color diceColor)
    {
        if(color == diceColor)
        {
            positionIndex++;
        }
    }
}
