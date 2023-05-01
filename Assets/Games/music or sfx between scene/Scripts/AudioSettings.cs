using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Sprite[] spriteMute; // sprite button. 0 = on, 1 = off

    [Header("System Music")]
    public Button muteMusicButton;
    public Slider volumeMusicSlider;

    [Header("System SFX")]
    public Button muteSFXButton;
    public Slider volumeSFXSlider;

    private void Start()
    {

        // * music
        if (AudioManager.Instance.audioSourceMusic.mute == true)
        {
            muteMusicButton.image.sprite = spriteMute[1];
        }
        else
        {
            muteMusicButton.image.sprite = spriteMute[0];
        }

        volumeMusicSlider.value = AudioManager.Instance.audioSourceMusic.volume;

        // * sfx
        if (AudioManager.Instance.audioSourceSFX.mute == true)
        {
            muteSFXButton.image.sprite = spriteMute[1];
        }
        else
        {
            muteSFXButton.image.sprite = spriteMute[0];
        }

        volumeSFXSlider.value = AudioManager.Instance.audioSourceSFX.volume;
    }

    #region music

    public void VolumeMusic()
    {
        AudioManager.Instance.audioSourceMusic.volume = volumeMusicSlider.value;

        if (volumeMusicSlider.value <= volumeMusicSlider.minValue)
        {
            AudioManager.Instance.audioSourceMusic.mute = true;
            muteMusicButton.image.sprite = spriteMute[1];
        }
        else
        {
            AudioManager.Instance.audioSourceMusic.mute = false;
            muteMusicButton.image.sprite = spriteMute[0];
        }
    }

    public void MusicMute()
    {
        AudioManager.Instance.MusicMute();

        if (AudioManager.Instance.audioSourceMusic.mute == true)
        {
            muteMusicButton.image.sprite = spriteMute[1];
        }
        else
        {
            muteMusicButton.image.sprite = spriteMute[0];
        }
    }

    #endregion

    #region sfx

    public void VolumeSfx()
    {
        AudioManager.Instance.audioSourceSFX.volume = volumeSFXSlider.value;

        if (volumeSFXSlider.value <= volumeSFXSlider.minValue)
        {
            AudioManager.Instance.audioSourceSFX.mute = true;
            muteSFXButton.image.sprite = spriteMute[1];
        }
        else
        {
            AudioManager.Instance.audioSourceSFX.mute = false;
            muteSFXButton.image.sprite = spriteMute[0];
        }
    }

    public void SfxMute()
    {
        AudioManager.Instance.SfxMute();

        if (AudioManager.Instance.audioSourceSFX.mute == true)
        {
            muteSFXButton.image.sprite = spriteMute[1];
        }
        else
        {
            muteSFXButton.image.sprite = spriteMute[0];
        }
    }

    #endregion

}
