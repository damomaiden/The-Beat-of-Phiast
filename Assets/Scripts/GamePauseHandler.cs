using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class GamePauseHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToPause;

    public void Start()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        foreach (GameObject obj in objectsToPause)
        {
            if (obj.TryGetComponent(out PlayableDirector director))
            {
                director.Pause();
            }
            else
            {
                obj.SetActive(false);
            }
        }
    }

    public void UnpauseGame()
    {
        foreach (GameObject obj in objectsToPause)
        {
            if (obj.TryGetComponent(out PlayableDirector director))
            {
                director.Play();
            }
            else
            {
                obj.SetActive(true);
            }
        }
    }
}
