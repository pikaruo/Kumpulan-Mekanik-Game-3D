using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // * Inisiate script mmusic Controller
    public static AudioManager Instance { get; set; }

    [Header("System Music")]
    public AudioSource audioSourceMusic;
    public SOMusicList dataMusic;

    [Header("System Sfx")]
    public AudioSource audioSourceSFX;
    public SOSfxList dataSFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region music

    // * This method for controll mute unmute music
    public void MusicMute()
    {
        if (audioSourceMusic.mute == false)
        {
            audioSourceMusic.mute = true; // mute music
        }
        else
        {
            audioSourceMusic.mute = false; // unmute music
        }
    }

    #endregion

    #region  sfx

    // * This method for controll mute unmute sfx 
    public void SfxMute()
    {
        if (audioSourceSFX.mute == false)
        {
            audioSourceSFX.mute = true; // mute music
        }
        else
        {
            audioSourceSFX.mute = false; // unmute music
        }
    }
    #endregion
}
