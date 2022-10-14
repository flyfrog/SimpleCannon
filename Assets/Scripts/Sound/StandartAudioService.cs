using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StandartAudioService : MonoBehaviour
{
    private VariablePithSound _variablePithSound;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _variablePithSound = new VariablePithSound(_audioSource, 0.8f, 1.3f);
    }


    protected void Play(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    protected void PlayVariable(AudioClip clip)
    {
        _variablePithSound.Play(clip);
    }
}