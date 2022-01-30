using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject Title;
    public GameObject Instructions;
    private void Start()
    {
        
    }

    public void playButtonClicked()
    {
        StartCoroutine(startRoutine());
    }
    IEnumerator startRoutine()
    {
        Title.SetActive(false);
        Instructions.SetActive(true);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("TextAdventure");
    }
}
