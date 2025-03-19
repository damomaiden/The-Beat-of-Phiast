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
    private string oldHighName;
    private string oldSecondName;
    private string oldThirdName;

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
        oldHighName = highScoreManager.scoreData.playerName;
        oldSecondScore = highScoreManager.scoreData.secondScore;
        oldSecondName = highScoreManager.scoreData.secondName;
        oldThirdScore = highScoreManager.scoreData.thirdScore;
        oldThirdName = highScoreManager.scoreData.thirdName;
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
        if (scoreNumber >= oldHighScore) //1st place
        {
            highScoreManager.scoreData.thirdScore = oldSecondScore;
            highScoreManager.scoreData.thirdName = oldSecondName;

            highScoreManager.scoreData.secondScore = oldHighScore;
            highScoreManager.scoreData.secondName = oldHighName;

            highScoreManager.scoreData.highScore = scoreNumber;
            highScoreManager.scoreData.playerName = whoAreYou.CurrentPlayerName;

            highScoreManager.SaveScores(); // Save updated scores
        }
        else if (scoreNumber >= oldSecondScore && scoreNumber <= oldHighScore) //2nd place
        {
            highScoreManager.scoreData.thirdScore = oldSecondScore;
            highScoreManager.scoreData.thirdName = oldSecondName;

            highScoreManager.scoreData.secondScore = scoreNumber;
            highScoreManager.scoreData.secondName = whoAreYou.CurrentPlayerName;

            highScoreManager.SaveScores(); // Save updated scores
        }
        else if (scoreNumber >= oldThirdScore && scoreNumber <= oldSecondScore) //3rd place
        {
            highScoreManager.scoreData.thirdScore = scoreNumber;
            highScoreManager.scoreData.thirdName = whoAreYou.CurrentPlayerName;

            highScoreManager.SaveScores(); // Save updated scores
        }
    }
}