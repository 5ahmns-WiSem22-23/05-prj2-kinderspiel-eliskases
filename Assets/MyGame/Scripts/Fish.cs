using System.Collections;
using UnityEngine;

public class Fish : Moveable
{



    public override IEnumerator CriticalCheckpoint()
    {
        GameManager.numCaught++;
        yield return new WaitForEndOfFrame();
        GameManager.checkpoints[checkpointIndex].movables.Remove(this);
        LuckyWheel.colorChosenDelegate -= Move;
        Destroy(gameObject);
    }

    public override void ReachSea()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
    }
}
