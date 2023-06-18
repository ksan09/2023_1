using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<AudioManager>();

            return instance;
        }
    }

    [SerializeField] List<AudioClip> clips = new List<AudioClip>();
    private Dictionary<string, AudioClip> clipPool = new Dictionary<string, AudioClip>();

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource systemPlayer = null;
    [SerializeField] AudioMixer masterMixer = null;
    private float minSound = -60f;
    private float maxSound = 20f;

    private void Awake()
    {
        foreach (AudioClip clip in clips)
            CreateAudioPool(clip);
    }

    private void Start()
    {
        SoundSetting();
    }

    public float GetVFXSound()
    {
        return PlayerPrefs.GetFloat("VFX");
    }
    public float GetBGMSound()
    {
        return PlayerPrefs.GetFloat("BGM");
    }
    public float GetMasterSound()
    {
        return PlayerPrefs.GetFloat("Master");
    }

    public void SetVFXSound(float value)
    {
        masterMixer.SetFloat("VFX", Mathf.Lerp(minSound, maxSound, value));
        PlayerPrefs.SetFloat("VFX", value);
    }
    public void SetBGMSound(float value)
    {
        masterMixer.SetFloat("BGM", Mathf.Lerp(minSound, maxSound, value));
        PlayerPrefs.SetFloat("BGM", value);
    }
    public void SetMasterSound(float value)
    {
        masterMixer.SetFloat("Master", Mathf.Lerp(minSound, maxSound, value));
        PlayerPrefs.SetFloat("Master", value);
    }

    private void SoundSetting()
    {
        SetVFXSound(GetVFXSound());
        SetBGMSound(GetBGMSound());
        SetMasterSound(GetMasterSound());
    }

    public void PlayBGM(string clipName) => PlayAudio(clipName, bgmPlayer);
    public void PauseBGM() => bgmPlayer.Pause();
    public void PlaySystem(string clipName) => PlayAudio(clipName, systemPlayer);
    public void PlaySystemBtnClick() => PlayAudio("BtnClick", systemPlayer);
    public void PauseSystem() => systemPlayer.Pause();

    public void PlayAudio(string clipName, AudioSource player)
    {
        if (!clipPool.ContainsKey(clipName))
        {
            Debug.LogWarning("Current name of auido clip doesnt exist");
            return;
        }

        player.clip = clipPool[clipName];
        player.Play();
    }

    private void CreateAudioPool(AudioClip clip)
    {
        if (clipPool.ContainsKey(clip.name))
        {
            Debug.LogWarning("Current name of audio clip is already exist");
            return;
        }

        clipPool.Add(clip.name, clip);
    }
}