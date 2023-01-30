using UnityEngine;
using System.Linq;

public class FishPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fishButtons;

    private void OnEnable()
    {
        foreach(GameObject buttonObj in fishButtons)
        {
            GameManager.Color color = buttonObj.GetComponent<ColorHelper>().color;

            if (GameManager.safeColors.Any(element => element == color) || GameManager.caughtColors.Any(element => element == color))
            {
                buttonObj.SetActive(false);
            }
        }
    }
}
