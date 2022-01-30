using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject Title;
    public GameObject Instructions;
    public GameObject Button;
    public tACurrentSceneManager sceneReference;
    private void Start()
    {
        
    }

    public void playButtonClicked()
    {
        //StartCoroutine(startRoutine());
        Title.SetActive(false);
        Instructions.SetActive(true);
        Button.SetActive(false);
        sceneReference.currentScene = 0;
        SceneManager.LoadScene("TextAdventure");
    }
    
    IEnumerator startRoutine()
    {                          
        Title.SetActive(false);
        Instructions.SetActive(true);
        Button.SetActive(false);
        sceneReference.currentScene = 0;
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("TextAdventure");

    }
    
}
