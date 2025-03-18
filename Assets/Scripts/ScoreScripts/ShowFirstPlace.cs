using UnityEngine;
using TMPro;

public class ShowFirstPlace : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI first; // Will show first place name here
    [SerializeField] TextMeshProUGUI firsts; // Will show first place score here
    [SerializeField] TextMeshProUGUI second; // Will show second place name here
    [SerializeField] TextMeshProUGUI seconds; // Will show second place score here
    [SerializeField] TextMeshProUGUI third; // Will show third place name here
    [SerializeField] TextMeshProUGUI thirds; // Will show third place score here

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
        else
        {
            Debug.Log("HighScoreManager instance found!");
        }

        // Ensure all names are valid (assign random names if missing)
        ValidateNames();

        // Update the UI with high score data
        UpdateUI();
    }

    void ValidateNames()
    {
        if (highScoreManager.scoreData != null)
        {
            // Check and assign random names if missing
            if (string.IsNullOrEmpty(highScoreManager.scoreData.playerName))
                highScoreManager.scoreData.playerName = GenerateRandomName();

            if (string.IsNullOrEmpty(highScoreManager.scoreData.secondName))
                highScoreManager.scoreData.secondName = GenerateRandomName();

            if (string.IsNullOrEmpty(highScoreManager.scoreData.thirdName))
                highScoreManager.scoreData.thirdName = GenerateRandomName();
        }
    }

    string GenerateRandomName()
    {
        // Generate a random 3-letter name (e.g., "ABC")
        string randomName = "";
        for (int i = 0; i < 3; i++)
        {
            char randomChar = (char)('A' + Random.Range(0, 26)); // Random letter from A to Z
            randomName += randomChar;
        }
        return randomName;
    }

    void UpdateUI()
    {
        if (highScoreManager != null && highScoreManager.scoreData != null)
        {
            // Update first place
            first.text = highScoreManager.scoreData.playerName;
            firsts.text = highScoreManager.scoreData.highScore.ToString();

            // Update second place
            second.text = highScoreManager.scoreData.secondName;
            seconds.text = highScoreManager.scoreData.secondScore.ToString();

            // Update third place
            third.text = highScoreManager.scoreData.thirdName;
            thirds.text = highScoreManager.scoreData.thirdScore.ToString();
        }
        else
        {
            Debug.LogWarning("HighScoreManager or scoreData is null!");
        }
    }
}