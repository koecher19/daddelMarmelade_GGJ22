using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "currentTASceneManager")]
public class tACurrentSceneManager : ScriptableObject
{

    public int currentScene;
    public bool debugEnabled;
    public bool goodChoice1;
    public bool goodChoice2;
    public bool goodChoice3;
    public bool goodChoice4;
    public bool goodChoice5;
    private void Awake()
    {
        goodChoice1 = false;
        goodChoice2 = false;
        goodChoice3 = false;
        goodChoice4 = false;
        goodChoice5 = false;
        debugEnabled = false;
        currentScene = 0;
    }
    
    public bool checkGoodChoices()
    {
        return (goodChoice1 == true && goodChoice2 == true && goodChoice3 == true && goodChoice4 == true && goodChoice5 == true);
    }
}
