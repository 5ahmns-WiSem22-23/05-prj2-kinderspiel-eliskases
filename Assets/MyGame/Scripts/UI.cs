using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI fishCount;
    [SerializeField]
    private GameObject wheelButton;
    [SerializeField]
    private GameObject startPanel;
    [SerializeField]
    private GameObject wheel;

    private void Start()
    {
       // It's only necessary to update the fish count once we have rolled the dice
        LuckyWheel.colorChosenDelegate += OnRoll;
        ToggleGameplay(false);
    }

    private void OnRoll(GameManager.Color color)
    {
        Invoke(nameof(UpdateFishCount), 0.25f);
    }

    private void UpdateFishCount()
    {
        fishCount.text = GameManager.numCaught.ToString(); 
    }

    public void SetGameMode(GameModeHelper helper)
    {
        GameManager.gameMode = helper.gameMode;
        ToggleGameplay(true);
    }

    private void ToggleGameplay(bool toggle)
    {
        fishCount.gameObject.SetActive(toggle);
        wheelButton.SetActive(toggle);
        wheel.SetActive(toggle);
        startPanel.SetActive(!toggle);
    }
}
