using System.Collections.Generic;
using UnityEngine;

public class Checkpoint
{
    public List<Movable> movables = new List<Movable>();
    public float xPos { get; private set; }

    public Checkpoint(float x)
    {
        xPos = x;
    }

    public void AddMovable(Movable movable)
    {
        movables.Add(movable);
        Vector2 pos = movable.gameObject.transform.position;
        pos.x = xPos;
        movable.gameObject.transform.position = pos;
    }
}