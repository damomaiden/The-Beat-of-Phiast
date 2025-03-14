using UnityEngine;
using System.IO;

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

public class JSON_Highscore : MonoBehaviour
{
    public ScoreData scoreData;
    private string filePath;

    // Static instance for singleton pattern
    public static JSON_Highscore Instance { get; private set; }

    private void Awake()
    {
        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("JSON_Highscore persistent data path: " + Application.persistentDataPath);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void Start()
    {
        // Set proper file path using Application.persistentDataPath
        filePath = Path.Combine(Application.persistentDataPath, "HighScores.json");
        Debug.Log("Full highscores file path: " + filePath);

        LoadScores();

        // Example: Update some data
        // scoreData.highScore = 1000;
        // scoreData.playerName = "Player1";

        SaveScores();
    }

    public void LoadScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            scoreData = JsonUtility.FromJson<ScoreData>(json);
            Debug.Log("Loaded scores from: " + filePath);
        }
        else
        {
            scoreData = new ScoreData();
            Debug.Log("No existing score file found at: " + filePath);
            Debug.Log("Created new score data. Will save to: " + Application.persistentDataPath);
        }
    }

    public void SaveScores()
    {
        string jsonToSave = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(filePath, jsonToSave);
        Debug.Log("Saved scores to: " + filePath);
    }
}