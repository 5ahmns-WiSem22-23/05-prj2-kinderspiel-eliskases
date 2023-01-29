using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Moveable : MonoBehaviour
{
    protected int checkpointIndex = 0;

    protected delegate void OnMove();
    protected OnMove onMoveDelegate;

    [SerializeField]
    private int headStart;
    public GameManager.Color[] colors;

    public AnimationCurve animationCurve;
    public float animationDuration;

    private void Start()
    {
        LuckyWheel.colorChosenDelegate += Move;

        checkpointIndex += headStart;
        GameManager.checkpoints[checkpointIndex].AddMovable(this);
    }

    protected void Move(GameManager.Color wheelColor)
    {
        if (!Array.Exists(colors, element => element == wheelColor)) return;
            
        checkpointIndex++;
        GameManager.checkpoints[checkpointIndex].AddMovable(this);

        if (checkpointIndex == GameManager.checkpoints.Count - 1)
        {
            GameManager.checkpoints[GameManager.checkpoints.Count - 1].movables.Remove(this);
            ReachSea();
            LuckyWheel.colorChosenDelegate -= Move;
        }

        onMoveDelegate?.Invoke();
    }

    public abstract IEnumerator CriticalCheckpoint();
    public abstract void ReachSea();
}
