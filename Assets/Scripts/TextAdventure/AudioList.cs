using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "audioList")]
public class AudioList : ScriptableObject
{
    public List<AudioClip> audios = new List<AudioClip>();
    private int listObjectsCount;

    public AudioClip stepSound;

    // Start is called before the first frame update
    void Awake()
    {
        if (audios.Count != 0)
            audios.RemoveRange(0, audios.Count);
        appointAudioLines();
    }

    // Update is called once per frame
    private void appointAudioLines()
    {
        audios.Add(null);
        audios.Add(stepSound);
    }
}