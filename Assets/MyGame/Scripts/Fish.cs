using System.Collections;
using UnityEngine;

public class Fish : Moveable
{
    public override IEnumerator CriticalCheckpoint()
    {
        yield return new WaitForEndOfFrame();
        GameManager.checkpoints[checkpointIndex].movables.Remove(this);
        GameManager.numCaught++;
        Dice.onRollDelegate -= Move;
        Destroy(this.gameObject);
    }
}
