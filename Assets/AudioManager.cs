using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public AudioMixerGroup soundEffectMixer;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }

        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (audioSource == null || playlist.Length == 0)
        {
            Debug.LogError("AudioSource or Playlist is not set correctly.");
            return;
        }

        audioSource.clip = playlist[musicIndex];
        audioSource.Play();

        //if (audioSource.outputAudioMixerGroup != null)
        //{
        //    audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Music", 0f); // 0 dB
        //}

    }
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }
    private void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        
        //ajoute un component audiosource a tempGO et en fait une variable en une seule ligne pour pouvoir la manipuler
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();

        Destroy(tempGO, clip.length);

        return audioSource;
    }
}
