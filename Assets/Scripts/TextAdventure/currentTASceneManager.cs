using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "currentTASceneManager")]
public class tACurrentSceneManager : ScriptableObject
{

    public int currentScene;
    public int nextSceneStart;
    public bool debugEnabled;
    public bool goodChoice1;
    public bool goodChoice2;
    public bool goodChoice3;
    public bool goodChoice4;
    public bool goodChoice5;
    public bool goodChoice6;
    private void Awake()
    {

    }
    
    public bool checkGoodChoices()
    {
        return (goodChoice1 == true && goodChoice2 == true && goodChoice3 == true && goodChoice4 == true && goodChoice5 == true && goodChoice6 == true);
    }
}
