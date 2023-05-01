using UnityEngine;

[CreateAssetMenu(fileName = "MusicList", menuName = "Audio/Music List")]
public class SOMusicList : ScriptableObject
{
    public AudioClip[] music;
}
