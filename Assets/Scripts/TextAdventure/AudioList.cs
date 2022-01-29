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
    public AudioClip nimues;
    public AudioClip esmira;

    public AudioClip stepSound;
    public AudioClip courtain;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip doorSlam;
    public AudioClip bookGrabing;
    public AudioClip slapSound;
    public AudioClip punchSound;
    public AudioClip wallBangSound;
    public AudioClip horrorLoop;
    public AudioClip normalLoop;
    public AudioClip scratching;
    public AudioClip fallingBody;

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
        audios.Add(normal);             //Normal        = 0  
        audios.Add(narrator);           //Narrator      = 1
        audios.Add(bruno);              //Bruno         = 2
        audios.Add(harvey);             //Harvey        = 3
        audios.Add(gordon);             //Gordon        = 4
        audios.Add(eugene);             //Eugene        = 5
        audios.Add(tori);               //Tori          = 6
        audios.Add(sunshine);           //Sunshine      = 7
        audios.Add(donna);              //Donna         = 8
        audios.Add(avery);              //Avery         = 9 
        audios.Add(celeste);            //Celeste       = 10
        audios.Add(nimues);             //Nimues        = 11
        audios.Add(esmira);             //Esmira        = 12
        audios.Add(stepSound);          //Steps         = 13
        audios.Add(courtain);           //Vorhang       = 14 
        audios.Add(doorOpen);           //door opening  = 15
        audios.Add(doorClose);          //door closing  = 16  
        audios.Add(doorSlam);           //door slaming  = 17
        audios.Add(bookGrabing);        //book grabing  = 18  
        audios.Add(slapSound);          //slapSound     = 19
        audios.Add(punchSound);         //punchSound    = 20
        audios.Add(wallBangSound);      //WallBanging   = 21
        audios.Add(horrorLoop);         //horrorLoop    = 22  
        audios.Add(normalLoop);         //normalLoop    = 23   
        audios.Add(scratching);         //scratching    = 24    
        audios.Add(fallingBody);        //fallingBody   = 25

    }
}