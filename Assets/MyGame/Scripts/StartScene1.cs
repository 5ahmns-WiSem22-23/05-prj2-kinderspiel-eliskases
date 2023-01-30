using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene1 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
