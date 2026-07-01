using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("MainGameScene");
        scoreKeeper.ResetScore();
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
