using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
       // It's only necessary to update the fish count once we have rolled the dice
        LuckyWheel.colorChosenDelegate += OnRoll;
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
    }

    private void EndPanel(string message)
    {
        ToggleGameplay(false, true);
        endText.text = message;
    }

    private void OnDisable()
    {
        LuckyWheel.colorChosenDelegate -= OnRoll;
        GameManager.gameEndedDelegate -= EndPanel;
    }
}
