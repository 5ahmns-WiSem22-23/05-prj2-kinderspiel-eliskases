using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField]
    private GameManager.Color color;

    public bool isSafe { get; private set; } = false;

    private void Start()
    {
        GameManager.allFish.Add(this);
        Dice.onRollDegate += Move;
    }

    void Move(GameManager.Color diceColor)
    {
        if (diceColor != color) return;

        float posX = transform.position.x + 1;
        float posY = transform.position.y;

        transform.position = new Vector2(posX, posY);
    }
}
