using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButtonScript : MonoBehaviour
{
    public tACurrentSceneManager tASceneManager;
    public int changeToSceneNumber;
    public void debugButtonClicked()
    {
        tASceneManager.currentScene = changeToSceneNumber;
    }
}
