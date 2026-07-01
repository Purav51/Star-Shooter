using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver()
    {
       StartCoroutine(waitAndLoad("GameOver", 1.9f));
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    IEnumerator waitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName); 
    }
}
