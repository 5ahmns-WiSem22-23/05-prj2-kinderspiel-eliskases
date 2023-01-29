using System.Collections;
using UnityEngine;

public class Fish : Moveable
{
    public override IEnumerator CriticalCheckpoint()
    {
        GameManager.numCaught++;
        yield return new WaitForEndOfFrame();
        GameManager.checkpoints[checkpointIndex].movables.Remove(this);
        GameManager.caughtColors.AddRange(colors);
        LuckyWheel.colorChosenDelegate -= Move;
        Destroy(gameObject);
    }

    public override void ReachSea()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        GameManager.numSafe++;
        GameManager.safeColors.AddRange(colors);

        if (GameManager.numSafe == 4) GameManager.EndGame();
    }

    private void OnDisable()
    {
        LuckyWheel.colorChosenDelegate -= Move;
    }
}
