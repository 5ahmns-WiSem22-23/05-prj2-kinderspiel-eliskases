using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI fishCount;

    private void Start()
    {
       // It's only necessary to update the fish count once we have rolled the dice
        Dice.onRollDelegate += OnRoll;
    }

    private void OnRoll(GameManager.Color color)
    {
        Invoke(nameof(UpdateFishCount), 0.25f);
    }

    private void UpdateFishCount()
    {
        fishCount.text = GameManager.numCaught.ToString(); 
    }
}
