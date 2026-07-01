using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Updater : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider HealthSlider;
    [SerializeField] Health playerHealth; 

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText; 
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        HealthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("00000000");
        HealthSlider.value = playerHealth.GetHealth(); 
    }
}
