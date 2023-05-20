using UnityEngine;

public class LoopAudio : MonoBehaviour
{
    public AudioClip llanoLoop;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = llanoLoop;
            audioSource.Play();
        }
    }
}
