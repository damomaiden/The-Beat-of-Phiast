using TMPro;
using UnityEngine;

public class NameInput : MonoBehaviour
{
    [SerializeField] HighScore_SO highScore; //Remebers the highest score from all previous play sessions
    [SerializeField] TextMeshPro text; //will write name here
    [SerializeField] int nameNumber = 10101; //Name is calculated on a scale of 010101 to 262626

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshPro>();

    }

    public void UpFirst()
    {
        nameNumber = nameNumber + 10000;
        if(nameNumber >= 270000)
        {
            nameNumber = nameNumber - 250000;
        }
    }

    public void DownFirst()
    {
        nameNumber = nameNumber - 100;
        if (nameNumber <= 10000)
        {
            nameNumber = nameNumber + 260000;
        }
    }

    public void UpSecond()
    {
        nameNumber = nameNumber + 100;
        if (nameNumber >= 2700)
        {
            nameNumber = nameNumber - 250000;
        }
    }

    public void DownSecond()
    {
        nameNumber = nameNumber - 100;
    }

    public void UpThird()
    {
        nameNumber = nameNumber + 1;
    }

    public void DownThird()
    {
        nameNumber = nameNumber - 1;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = highScore.playerName.ToString();
    }
}
