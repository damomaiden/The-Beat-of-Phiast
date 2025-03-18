using UnityEngine;

// Define ScoreData in a unique namespace to avoid conflicts
namespace HighScoreSystem
{
    [System.Serializable]
    public class ScoreData
    {
        public int highScore;
        public string playerName;
        public int secondScore;
        public string secondName;
        public int thirdScore;
        public string thirdName;
    }
}

public class HighScoreManager : MonoBehaviour
{
    public HighScoreSystem.ScoreData scoreData; // Use fully qualified name

    // Static instance for singleton pattern
    public static HighScoreManager Instance { get; private set; }

    private void Awake()
    {
        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadScores();
    }

    public void LoadScores()
    {
        // Load high scores from PlayerPrefs
        scoreData.highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreData.playerName = PlayerPrefs.GetString("HighScoreName", "AAA");
        scoreData.secondScore = PlayerPrefs.GetInt("SecondScore", 0);
        scoreData.secondName = PlayerPrefs.GetString("SecondScoreName", "AAA");
        scoreData.thirdScore = PlayerPrefs.GetInt("ThirdScore", 0);
        scoreData.thirdName = PlayerPrefs.GetString("ThirdScoreName", "AAA");
    }

    public void SaveScores()
    {
        // Save high scores to PlayerPrefs
        PlayerPrefs.SetInt("HighScore", scoreData.highScore);
        PlayerPrefs.SetString("HighScoreName", scoreData.playerName);
        PlayerPrefs.SetInt("SecondScore", scoreData.secondScore);
        PlayerPrefs.SetString("SecondScoreName", scoreData.secondName);
        PlayerPrefs.SetInt("ThirdScore", scoreData.thirdScore);
        PlayerPrefs.SetString("ThirdScoreName", scoreData.thirdName);

        PlayerPrefs.Save(); // Ensure data is written to disk
    }
}