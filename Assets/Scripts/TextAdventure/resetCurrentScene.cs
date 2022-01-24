using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCurrentScene : MonoBehaviour
{
    public tACurrentSceneManager sceneManager;

    public void resetButtonClicked()
    {
        sceneManager.currentScene = 0;
    }

}
