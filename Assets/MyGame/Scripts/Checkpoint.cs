using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint
{
    public List<Moveable> movables = new List<Moveable>();

    private float xPos;
    private int index;

    private readonly float Y_ANIMATION_SCALE = 0.2f;

    public Checkpoint(float x, int cpIndex)
    {
        xPos = x;
        index = cpIndex;
    }

    public void AddMovable(Moveable moveable)
    {
        movables.Add(moveable);

        if(index != 0)
        {
            GameManager.checkpoints[index - 1].movables.Remove(moveable);
        }

        moveable.StartCoroutine(Animate(moveable));
    }

    private IEnumerator Animate(Moveable moveable)
    {
        YieldInstruction instruction = new WaitForEndOfFrame();

        Vector2 origin = moveable.transform.position;
        Vector2 destination = new Vector2(xPos, origin.y);

        Vector2 currentPos;

        float currentLerpTime = 0;
        float clampLerpTime = 0;

        while (true)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= moveable.animationDuration)
            {
                break;
            }

            clampLerpTime = Mathf.Clamp01(currentLerpTime / moveable.animationDuration);
            currentPos = Vector3.Lerp(origin, destination, moveable.animationCurve.Evaluate(clampLerpTime));

            currentPos.y = origin.y - Mathf.Sin(clampLerpTime * 2 * Mathf.PI) * Y_ANIMATION_SCALE;

            moveable.transform.position = currentPos;
            yield return instruction;
        }
    }
}