using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "audioList")]
public class AudioList : ScriptableObject
{
    public List<AudioClip> audios = new List<AudioClip>();
    private int listObjectsCount;

    public AudioClip normal;
    public AudioClip narrator;
    public AudioClip bruno;
    public AudioClip harvey;
    public AudioClip gordon;
    public AudioClip eugene;
    public AudioClip tori;
    public AudioClip sunshine;
    public AudioClip donna;
    public AudioClip avery;
    public AudioClip celeste;
    public AudioClip esmira;
    public AudioClip nimues;

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
        audios.Add(null);               //Normal        = 0  
        audios.Add(null);               //Narrator      = 1
        audios.Add(bruno);              //Bruno         = 2
        audios.Add(harvey);             //Harvey        = 3
        audios.Add(gordon);             //Gordon        = 4
        audios.Add(eugene);             //Eugene        = 5
        audios.Add(tori);               //Tori          = 6
        audios.Add(sunshine);           //Sunshine      = 7
        audios.Add(donna);              //Donna         = 8
        audios.Add(avery);              //Avery         = 9 
        audios.Add(celeste);            //Celeste       = 10
        audios.Add(esmira);             //Esmira        = 11
        audios.Add(nimues);             //Nimues        = 12
        audios.Add(stepSound);          //Steps         = 13
    }
}