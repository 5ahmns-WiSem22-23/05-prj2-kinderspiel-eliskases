using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI fishCount;
    [SerializeField]
    private GameObject wheelButton;
    [SerializeField]
    private GameObject startPanel;
    [SerializeField]
    private GameObject endPanel;
    [SerializeField]
    private GameObject wheel;
    [SerializeField]
    private TextMeshProUGUI endText;
    [SerializeField]
    private GameObject fishPanel;

    private void Start()
    {
        fishCount.text = "0";

        LuckyWheel.colorChosenDelegate += OnRoll;
        LuckyWheel.colorChosenDelegate += ShowFishPanel;
        GameManager.gameEndedDelegate += EndPanel;

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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ToggleGameplay(bool toggle, bool end = false)
    {
        fishCount.gameObject.SetActive(toggle);
        wheelButton.SetActive(toggle);
        wheel.SetActive(toggle);
        startPanel.SetActive(!toggle && !end);
        endPanel.SetActive(!toggle && end);

        fishPanel.SetActive(false);
    }

    private void EndPanel(string message)
    {
        ToggleGameplay(false, true);
        endText.text = message;
    }

    private void ShowFishPanel(GameManager.Color wheelColor)
    {
        if (!GameManager.safeColors.Any( element => element == wheelColor)) return;
        fishPanel.SetActive(true);
    }

    public void ChooseFish(Fish fish)
    {
        fishPanel.SetActive(false);
        LuckyWheel.colorChosenDelegate?.Invoke(fish.colors[0]);
    }


    private void OnDisable()
    {
        LuckyWheel.colorChosenDelegate -= OnRoll;
        LuckyWheel.colorChosenDelegate -= ShowFishPanel;
        GameManager.gameEndedDelegate -= EndPanel;
    }
}
