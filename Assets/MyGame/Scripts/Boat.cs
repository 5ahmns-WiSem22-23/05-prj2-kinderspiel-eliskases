using System.Collections;
using System.Linq;

public class Boat : Moveable
{
    public override IEnumerator CriticalCheckpoint()
    {
        yield return 0;
        GameManager.CheckIfGameEnded();
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
        // The game definitely ended at this point
        GameManager.CheckIfGameEnded();
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
