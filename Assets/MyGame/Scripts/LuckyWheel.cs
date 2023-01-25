using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LuckyWheel : MonoBehaviour
{
    [SerializeField]
    private GameObject rotationHandler;
    [SerializeField]
    private float rotationFrequency;
    [SerializeField]
    private AnimationCurve animationCurve;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    private bool isSpinning = false;
    private float defaultScale;

    public delegate void OnColorChosen(GameManager.Color color);
    public static OnColorChosen colorChosenDelegate;

    private Coroutine spinCoroutine;

    private void Start()
    {
        defaultScale = transform.localScale.x;
        StartCoroutine(ScaleWheel(0.5f * defaultScale));
        buttonText.text = "Spin";
    }

    public void OnButtonPressed()
    {
        if (isSpinning)
        {
            buttonText.text = "Spin";
            StopSpinning();
        } else
        {
            buttonText.text = "Stop";
            StartSpinning();
        }
    }

    private void StartSpinning()
    {
        isSpinning = true;
        spinCoroutine = StartCoroutine(Spin());
        StartCoroutine(ScaleWheel(defaultScale));
    }

    private IEnumerator Spin()
    {
        YieldInstruction instruction = new WaitForEndOfFrame();
        
        while (true)
        {
            Vector3 rot = rotationHandler.transform.rotation.eulerAngles;
            rot.z -= Time.deltaTime * 360 * rotationFrequency;
            rotationHandler.transform.rotation = Quaternion.Euler(rot);
            yield return instruction;
        }
    }

    private IEnumerator ScaleWheel(float scale)
    {
        YieldInstruction instruction = new WaitForEndOfFrame();

        Vector2 origin = gameObject.transform.localScale;
        Vector2 destination = new Vector2(1, 1) * scale;

        Vector2 currentScale;

        float currentLerpTime = 0;
        float clampLerpTime = 0;
        float duration = 1;

        while (true)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= duration)
            {
                break;
            }

            clampLerpTime = Mathf.Clamp01(currentLerpTime / duration);
            currentScale = Vector3.Lerp(origin, destination, animationCurve.Evaluate(clampLerpTime));

            transform.localScale = currentScale;
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

    private void StopSpinning()
    {
        isSpinning = false;
        StopCoroutine(spinCoroutine);
        StartCoroutine(ScaleWheel(defaultScale * 0.5f));

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
