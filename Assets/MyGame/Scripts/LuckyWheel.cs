using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyWheel : MonoBehaviour
{
    [SerializeField]
    private GameObject rotationHandler;
    [SerializeField]
    private float rotationFrequency;

    private bool isSpinning;

    public delegate void OnColorChosen(GameManager.Color color);
    public static OnColorChosen colorChosenDelegate;

    private Coroutine coroutine;

    public void StartSpinning()
    {
        coroutine = StartCoroutine(Spin());
    }

    private IEnumerator Spin()
    {
        if (isSpinning) yield break;
        isSpinning = true;

        YieldInstruction instruction = new WaitForEndOfFrame();
        

        while (true)
        {
            Vector3 rot = rotationHandler.transform.rotation.eulerAngles;
            rot.z -= Time.deltaTime * 360 * rotationFrequency;
            rotationHandler.transform.rotation = Quaternion.Euler(rot);
            yield return instruction;
        }
    }

    struct FishData
    {
        public FishData(GameManager.Color fishColor, float fishAngle)
        {
            color = fishColor;
            angle = fishAngle;
        }

        public GameManager.Color color;
        public float angle;
    }

    public void StopSpinning()
    {
        if (!isSpinning) return;
        isSpinning = false;
        StopCoroutine(coroutine);

        FishData[] fishData = {
            new FishData(GameManager.Color.Blue, 0),
            new FishData(GameManager.Color.Pink, 90),
            new FishData(GameManager.Color.Orange, 180),
            new FishData(GameManager.Color.Yellow, 270)
        };

        float alpha = rotationHandler.transform.eulerAngles.z;

        float closest = 22.5f;
        GameManager.Color chosenColor = GameManager.Color.Green;

        for(int i = 0; i < fishData.Length; i++)
        {
            float dist = Mathf.Abs(fishData[i].angle - alpha);
            if(dist < closest)
            {
                closest = dist;
                chosenColor = fishData[i].color;
            }
        }

        colorChosenDelegate?.Invoke(chosenColor);
    }
}
