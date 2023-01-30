using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Boat : Moveable
{
    public override IEnumerator CriticalCheckpoint()
    {
        if (GameManager.numCaught + GameManager.numSafe >= 4) GameManager.EndGame();
        yield break;
    }

    private void OnEnable()
    {
        onMoveDelegate += Moved;
        LuckyWheel.colorChosenDelegate += FishAlreadyCaught;
    }

    private void Moved()
    {
        GameManager.checkpoints[checkpointIndex].movables.ForEach(element => StartCoroutine(element.CriticalCheckpoint()));
    }

    public override void ReachSea()
    {
        GameManager.EndGame();
    }

    private void FishAlreadyCaught(GameManager.Color wheelColor)
    {
        if (!GameManager.caughtColors.Any(element => element == wheelColor)) return;
        LuckyWheel.colorChosenDelegate?.Invoke(colors[0]);
    }

    private void OnDisable()
    {
        onMoveDelegate -= Moved;
        LuckyWheel.colorChosenDelegate -= FishAlreadyCaught;
        LuckyWheel.colorChosenDelegate -= Move;
    }
}
