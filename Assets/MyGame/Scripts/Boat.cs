using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Moveable
{
    public override IEnumerator CriticalCheckpoint()
    {
        if (GameManager.numCaught == 4) GameManager.EndGame();
        yield break;
    }

    private void OnEnable()
    {
        onMoveDelegate += Moved;
    }

    private void Moved()
    {
        GameManager.checkpoints[checkpointIndex].movables.ForEach(element => StartCoroutine(element.CriticalCheckpoint()));
    }

    public override void ReachSea()
    {
        GameManager.EndGame();
    }
}
