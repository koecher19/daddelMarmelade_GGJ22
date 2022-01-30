using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public GameObject sceneChangeTrigger;
    public tACurrentSceneManager sceneReference;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        var sceneTransitions = new List<(string thisScene, string nextScene, int nextSceneStartScene)>
        {
            ("6-Sidescroller", "7-Sidescroller", 73),
            ("7-Sidescroller", "TextAdventure", 73),
            ("10-Sidescroller", "11-Sidescroller", 253),
            ("11-Sidescroller", "TextAdventure", 253),
            ("15-Sidescroller", "16-Sidescroller", 300),
            ("16-Sidescroller", "TextAdventure", 300)
        };

        if (trig.gameObject.tag == "sceneChangeTrigger")
        {
            foreach (var tupel in sceneTransitions)
            {
                if(tupel.thisScene == SceneManager.GetActiveScene().name)
                {
                    Debug.Log(sceneReference);
                    sceneReference.currentScene = tupel.nextSceneStartScene;
                    SceneManager.LoadScene(tupel.nextScene);
                    sceneReference.currentScene = tupel.nextSceneStartScene;
                }
            }
            
        }
    }
}