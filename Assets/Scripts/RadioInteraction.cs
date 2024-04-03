using UnityEngine;

public class RadioInteraction : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleAudio()
    {
        isPlaying = !isPlaying;

        if (isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
