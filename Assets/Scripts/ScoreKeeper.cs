using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore = 0;

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void ModifyScore(int ScoretoAdd)
    {
        currentScore += ScoretoAdd;
        currentScore = Mathf.Clamp(currentScore, 0, int.MaxValue); //ensure score doesn't go below 0.
        // print(currentScore);
    }
    public void ResetScore()
    {
        currentScore = 0;
    } 
}
