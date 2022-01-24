using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "currentTASceneManager")]
public class currentTASceneManager : ScriptableObject
{

    public int currentScene;
    private void Awake()
    {
        currentScene = 0;
    }
}
