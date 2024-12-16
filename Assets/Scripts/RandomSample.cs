using NUnit.Framework;
using UnityEngine;

public class RandomSample : MonoBehaviour
{

    [SerializeField] AudioClip[] clips;
    AudioSource myAudioSource;

    private void Start()
    {
     myAudioSource = GetComponent<AudioSource>();   
    }
    private void OnTriggerEnter(Collider other)
    {
        myAudioSource.clip = clips[Random.Range(0, clips.Length-1)];
        myAudioSource.Play();
    }


}
