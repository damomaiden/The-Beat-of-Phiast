using UnityEngine;
using TMPro;
public class highscoreUpdater : MonoBehaviour //This script controls the part of the UI that shows the highest score of all playthroughs recorded
{
    [SerializeField] HighScore_SO highScore;
    [SerializeField] TextMeshPro text;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = highScore.highScore.ToString() ;
    }
}
