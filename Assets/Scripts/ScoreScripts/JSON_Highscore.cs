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

    public void Start()
    {
        // Set proper file path using Application.persistentDataPath
        filePath = Path.Combine(Application.persistentDataPath, "HighScores.json");

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
            Debug.Log("No existing score file found. Created new score data.");
        }
    }

    public void SaveScores()
    {
        string jsonToSave = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(filePath, jsonToSave);
        Debug.Log("Saved scores to: " + filePath);
    }
}

//using UnityEngine; //Old version
//
//[System.Serializable]
//public class ScoreData
//{
//    public int highScore;
//    public string playerName;
//    public int secondScore;
//    public string secondName;
//    public int thirdScore;
//    public string thirdName;
//}
//
//public class JSON_Highscore : MonoBehaviour
//{
//    public ScoreData scoreData;
//
//    public void Start()
//    {
//        // Example of loading JSON from a file
//        string json = System.IO.File.ReadAllText("JSON_Highscore.json");
//        scoreData = JsonUtility.FromJson<ScoreData>(json);
//
//        // Example of saving JSON to a file
//        string jsonToSave = JsonUtility.ToJson(scoreData);
//        System.IO.File.WriteAllText("scoreData.json", jsonToSave);
//    }
//}
//