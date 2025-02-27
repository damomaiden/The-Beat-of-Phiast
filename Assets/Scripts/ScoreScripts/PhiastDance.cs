using UnityEngine;

public class PhiastDance : MonoBehaviour
{
    public GameObject SplishSplash; //This is the variable to control the "Splash" particles

    private void Start()
    {
        SplishSplash.SetActive(false);
    }

    // This script is to control the particle effects so that when An Phiast moves in the water there is a splash
    public void LeftSplash() //Left leg's splash control
    {
        SplishSplash.SetActive(true);
        
    }

    public void RightSplash() //Right leg's splash control
    {
        //Neither are hooked up yet
    }
}
