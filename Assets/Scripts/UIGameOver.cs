using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    void Start()
    {
        scoreText.text = "Final Score: \n " + scoreKeeper.GetCurrentScore();
    }
}
