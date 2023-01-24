using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Moveable
{
    public override IEnumerator CriticalCheckpoint()
    {
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
}
