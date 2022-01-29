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
    public AudioClip meatDrippin;
    public AudioClip knocking;
    public AudioClip toriSigh;
    public AudioClip toriLaugh;
    public AudioClip whisper1;
    public AudioClip whisper2;
    public AudioClip nervousLaughter;
    public AudioClip clearThroat;
    public AudioClip fullWhisper;
    public AudioClip kiss;
    public AudioClip toriCry;


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
        audios.Add(courtain);           //Courtain      = 14 
        audios.Add(doorOpen);           //Door opening  = 15
        audios.Add(doorClose);          //Door closing  = 16  
        audios.Add(doorSlam);           //Door slaming  = 17
        audios.Add(bookGrabing);        //Book grabing  = 18  
        audios.Add(slapSound);          //SlapSound     = 19
        audios.Add(punchSound);         //PunchSound    = 20
        audios.Add(wallBangSound);      //WallBanging   = 21
        audios.Add(horrorLoop);         //HorrorLoop    = 22  
        audios.Add(normalLoop);         //NormalLoop    = 23   
        audios.Add(scratching);         //Scratching    = 24    
        audios.Add(fallingBody);        //FallingBody   = 25   
        audios.Add(meatDrippin);        //MeatDrippin   = 26   
        audios.Add(knocking);           //Knocking      = 27
        audios.Add(toriSigh);           //ToriSigh      = 28
        audios.Add(toriLaugh);          //toriLaugh     = 29  
        audios.Add(whisper1);           //whisper1      = 30   
        audios.Add(whisper2);           //whisper2      = 31   
        audios.Add(nervousLaughter);    //NevousLaughter= 32   
        audios.Add(clearThroat);        //clearingThroat= 33
        audios.Add(fullWhisper);        //FullWhisper   = 34  
        audios.Add(kiss);               //kiss          = 35   
        audios.Add(toriCry);            //toriCry       = 36

    }
}