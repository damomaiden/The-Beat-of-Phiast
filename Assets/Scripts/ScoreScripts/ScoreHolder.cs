using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public int scoreNumber = 0; // The amount of points you've gotten from hitting cubes
    public int comboMeter = 0; // The amount of cubes you've hit consecutively
    public int comboMulti = 1; // The amount your score is multiplied per cube broken

    [SerializeField] Name_SO whoAreYou; // Remembers the current player's name

    private int oldHighScore;
    private int oldSecondScore;
    private int oldThirdScore;

    private HighScoreManager highScoreManager;

    void Start()
    {
        // Access the HighScoreManager instance
        highScoreManager = HighScoreManager.Instance;

        if (highScoreManager == null)
        {
            Debug.LogError("HighScoreManager instance not found!");
            return;
        }

        // Initialize high scores
        oldHighScore = highScoreManager.scoreData.highScore;
        oldSecondScore = highScoreManager.scoreData.secondScore;
        oldThirdScore = highScoreManager.scoreData.thirdScore;
    }

    void Update()
    {
        // Controls the combo multiplier
        if (comboMeter < 5)
        {
            comboMulti = 1;
        }
        else if (comboMeter > 4 && comboMeter < 10)
        {
            comboMulti = 2;
        }
        else if (comboMeter > 9 && comboMeter < 15)
        {
            comboMulti = 4;
        }
        else if (comboMeter >= 15)
        {
            comboMulti = 8;
        }

        // Update high scores if necessary
        if (scoreNumber >= oldHighScore)
        {
            highScoreManager.scoreData.thirdScore = highScoreManager.scoreData.secondScore;
            highScoreManager.scoreData.thirdName = highScoreManager.scoreData.secondName;
            highScoreManager.scoreData.secondScore = highScoreManager.scoreData.highScore;
            highScoreManager.scoreData.secondName = highScoreManager.scoreData.playerName;
            highScoreManager.scoreData.highScore = scoreNumber;
            highScoreManager.scoreData.playerName = whoAreYou.CurrentPlayerName;

            highScoreManager.SaveScores(); // Save updated scores
        }
        else if (scoreNumber >= oldSecondScore && scoreNumber <= oldHighScore)
        {
            highScoreManager.scoreData.thirdScore = highScoreManager.scoreData.secondScore;
            highScoreManager.scoreData.thirdName = highScoreManager.scoreData.secondName;
            highScoreManager.scoreData.secondScore = scoreNumber;
            highScoreManager.scoreData.secondName = whoAreYou.CurrentPlayerName;

            highScoreManager.SaveScores(); // Save updated scores
        }
        else if (scoreNumber >= oldThirdScore && scoreNumber <= oldSecondScore)
        {
            highScoreManager.scoreData.thirdScore = scoreNumber;
            highScoreManager.scoreData.thirdName = whoAreYou.CurrentPlayerName;

            highScoreManager.SaveScores(); // Save updated scores
        }
    }
}