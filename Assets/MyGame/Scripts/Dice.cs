using UnityEngine;

public class Dice : MonoBehaviour
{
    public delegate void OnRoll(GameManager.Color color);
    public static OnRoll onRollDelegate;

    [SerializeField]
    private SpriteRenderer front;

    public void Roll()
    {
        int index = Random.Range(0, 6);
        GameManager.Color color = (GameManager.Color)index;
        onRollDelegate?.Invoke(color);

        switch(color)
        {
            case GameManager.Color.Blue:
                front.color = Color.blue;
                break;
            case GameManager.Color.Green:
                front.color = Color.green;
                break;
            case GameManager.Color.Orange:
                front.color = new Color(1, 0.5f, 0);
                break;
            case GameManager.Color.Pink:
                front.color = Color.magenta;
                break;
            case GameManager.Color.Red:
                front.color = Color.red;
                break;
            case GameManager.Color.Yellow:
                front.color = Color.yellow;
                break;
        }
    }
}
