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
        Dice.onRollDelegate += UpdateFishCount;
    }

    private void UpdateFishCount(GameManager.Color color)
    {
        fishCount.text = GameManager.numCaught.ToString();
    }
}
