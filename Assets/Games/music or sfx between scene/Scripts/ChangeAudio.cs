using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{

    [Header("System Music")]
    public int indexMusic;
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

    public void ChangeMusic(int indexMusic)
    {
        if (AudioManager.Instance.audioSourceMusic.clip != AudioManager.Instance.clipMusic[indexMusic])
        {
            AudioManager.Instance.audioSourceMusic.Stop(); // stop audio
            AudioManager.Instance.audioSourceMusic.clip = AudioManager.Instance.clipMusic[indexMusic]; // change audio by index
            AudioManager.Instance.audioSourceMusic.Play(); // play music
        }
    }

    #endregion

    #region sfx
    public void CoinSfx()
    {
        AudioManager.Instance.audioSourceSFX.PlayOneShot(AudioManager.Instance.clipCoin);
    }

    public void ItemSfx()
    {
        AudioManager.Instance.audioSourceSFX.PlayOneShot(AudioManager.Instance.clipItem);
    }
    #endregion
}
