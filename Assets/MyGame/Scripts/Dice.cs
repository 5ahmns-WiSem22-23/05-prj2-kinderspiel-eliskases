using UnityEngine;

public class Dice : MonoBehaviour
{
    public delegate void OnRoll(GameManager.DiceColor color);
    public static OnRoll onRollDegate;

    public void Roll()
    {
        int index = Random.Range(0, 6);
        GameManager.DiceColor color = (GameManager.DiceColor)index;
        onRollDegate?.Invoke(color);
    }
}
