using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheel : MonoBehaviour
{
    public delegate void OnSpin(GameManager.Color color);
    public static OnSpin onSpinDelegate;

    public IEnumerator StartSpinning()
    {
        YieldInstruction instruction = new WaitForEndOfFrame();

        while (true)
        {
            yield return instruction;
        }
    }

    private void Update()
    {
        StopSpinning();
    }

    public void StopSpinning()
    {
        float alpha = transform.rotation.z;
    }
}
