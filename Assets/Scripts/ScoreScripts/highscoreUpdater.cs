using UnityEngine;
using TMPro;
public class highscoreUpdater : MonoBehaviour //This script controls the part of the UI that shows the highest score of all playthroughs recorded
{
    [SerializeField] HighScore_SO highScore; //access highscores
    [SerializeField] TextMeshPro text; //will write highest score to here
    
    [SerializeField] TextMeshPro secondtext; //will write 2nd highest score to here

    [SerializeField] TextMeshPro thirdtext; //will write 3rd highest score to here

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        secondtext = GetComponent<TextMeshPro>();
        thirdtext = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update() //writing the highscores
    {
        text.text = highScore.highScore.ToString() ;
        secondtext.text = highScore.secondScore.ToString();
        thirdtext.text = highScore.thirdScore.ToString();
    }
}
