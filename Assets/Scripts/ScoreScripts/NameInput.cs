using TMPro;
using UnityEngine;

public class NameInput : MonoBehaviour
{
    [SerializeField] HighScore_SO highScore; //Remebers the highest score from all previous play sessions
    [SerializeField] TextMeshPro text; //will write name here
    [SerializeField] int nameNumber = 10101; //Name is calculated on a scale of 010101 to 262626
    [SerializeField] int midNumber = 101; //For calculating changes made to the middle number
    [SerializeField] int smallNumber = 1; //For calculating changes made to the smaller number

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
        nameNumber = nameNumber - 10000;
        if (nameNumber < 10000)
        {
            nameNumber = nameNumber + 260000;
        }
    }

    public void UpSecond()
    {
        nameNumber = nameNumber + 100;
        nameNumber = midNumber + 100;
        if (midNumber >= 2700)
        {
            nameNumber = nameNumber - 2500;
            midNumber = midNumber - 2500;
        }
    }

    public void DownSecond()
    {
        nameNumber = nameNumber - 100;
        nameNumber = midNumber - 100;
        if (midNumber < 100)
        {
            nameNumber = nameNumber + 2600;
            midNumber = midNumber + 2600;
        }
    }

    public void UpThird()
    {
        nameNumber = nameNumber + 1;
        nameNumber = smallNumber + 1;
        if (smallNumber >= 27)
        {
            nameNumber = nameNumber - 25;
            smallNumber = smallNumber - 25;
        }
    }

    public void DownThird()
    {
        nameNumber = nameNumber - 1;
        nameNumber = smallNumber + 1;
        if (smallNumber < 1)
        {
            nameNumber = nameNumber + 26;
            smallNumber = smallNumber + 26;
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = highScore.playerName.ToString();
    }
}
