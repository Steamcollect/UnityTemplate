using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    int currentMusicIndex = -1;
    AudioSource audioSource;

    public AudioMixerGroup soundMixerGroup;

    public AudioMixer audioMixer;

    public static AudioManager instance;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        instance = this;
    }

    private void Update()
    {
        if (!audioSource.isPlaying && playlist.Length > 0)
        {
            currentMusicIndex = (currentMusicIndex + 1) % playlist.Length;
            audioSource.clip = playlist[currentMusicIndex];
            audioSource.Play();
        }
    }

    public void PlayClipAt(float spatialBlend, Vector2 pos, AudioClip clip)
    {
        AudioSource tmpAudioClip = new GameObject("tmp Audio Go").AddComponent<AudioSource>();
        tmpAudioClip.transform.position = pos;
        tmpAudioClip.spatialBlend = spatialBlend;
        tmpAudioClip.outputAudioMixerGroup = soundMixerGroup;
        tmpAudioClip.clip = clip;
        tmpAudioClip.Play();
        Destroy(tmpAudioClip.gameObject, clip.length + .01f);
    }
}