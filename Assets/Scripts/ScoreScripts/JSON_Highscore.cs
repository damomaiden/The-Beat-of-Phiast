using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public int highScore = 0;
    public string playerName = "   ";
    public int secondScore = 0;
    public string secondName = "   ";
    public int thirdScore = 0;
    public string thirdName = "   ";
}

public class JSON_Highscore : MonoBehaviour
{
    public ScoreData scoreData;

    public void Start()
    {
        // Example of loading JSON from a file
        string json = System.IO.File.ReadAllText("JSON_Highscore.json");
        scoreData = JsonUtility.FromJson<ScoreData>(json);

        // Example of saving JSON to a file
        string jsonToSave = JsonUtility.ToJson(scoreData);
        System.IO.File.WriteAllText("scoreData.json", jsonToSave);
    }
}
