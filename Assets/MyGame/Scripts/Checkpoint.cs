using System.Collections.Generic;
using UnityEngine;

public class Checkpoint
{
    public List<Moveable> movables = new List<Moveable>();

    private float xPos;
    private int index;

    public Checkpoint(float x, int cpIndex)
    {
        xPos = x;
        index = cpIndex;
    }

    public void AddMovable(Moveable moveable)
    {
        movables.Add(moveable);
        Vector2 pos = moveable.gameObject.transform.position;
        pos.x = xPos;
        moveable.gameObject.transform.position = pos;

        if(index != 0)
        {
            GameManager.checkpoints[index - 1].movables.Remove(moveable);
        }

        if(index == GameManager.checkpoints.Count - 1)
        {
            moveable.ReachSea();
        }
    }
}