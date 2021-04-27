
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void RestartScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        Ball.singleton.isEnded = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
