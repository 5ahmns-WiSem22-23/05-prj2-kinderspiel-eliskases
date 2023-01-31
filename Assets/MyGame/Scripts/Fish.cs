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
        StartCoroutine(SwimToOcean());
    }

    private void OnDisable()
    {
        LuckyWheel.colorChosenDelegate -= Move;
    }

    private IEnumerator SwimToOcean()
    {
        // We need to wait a frame to execute this
        yield return 0;
        GameManager.numSafe++;
        GameManager.safeColors.AddRange(colors);
        GameManager.CheckIfGameEnded();

        YieldInstruction instruction = new WaitForEndOfFrame();

        Vector2 origin = transform.position;
        Vector2 destination = new Vector2(origin.x + 8, origin.y);

        Vector2 currentPos;

        float currentLerpTime = 0;
        float clampLerpTime = 0;

        const float duration = 3;

        while (true)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= duration)
            {
                break;
            }

            clampLerpTime = Mathf.Clamp01(currentLerpTime / duration);
            currentPos = Vector3.Lerp(origin, destination, animationCurve.Evaluate(clampLerpTime));

            transform.position = currentPos;
            yield return instruction;
        }
    }
}
