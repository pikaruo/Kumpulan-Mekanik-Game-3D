using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{

    [Header("System Music")]
    [SerializeField] private int indexMusic;
    public static int playIndexMusic;

    private void Start()
    {
        playIndexMusic = indexMusic;

        if (GameObject.Find("Audio Manager") != null)
        {
            ChangeMusic(playIndexMusic);
        }
    }

    #region music

    // * This method for change music other scene
    public void ChangeMusic(int indexMusic)
    {
        if (AudioManager.Instance.audioSourceMusic.clip != AudioManager.Instance.dataMusic.music[indexMusic])
        {
            AudioManager.Instance.audioSourceMusic.Stop(); // stop audio
            AudioManager.Instance.audioSourceMusic.clip = AudioManager.Instance.dataMusic.music[indexMusic]; // change audio by index
            AudioManager.Instance.audioSourceMusic.Play(); // play music
        }
    }

    #endregion

    #region sfx

    public void Sfx(int indexSfx)
    {
        AudioManager.Instance.audioSourceSFX.PlayOneShot(AudioManager.Instance.dataSFX.sfx[indexSfx]);
    }
    #endregion
}
