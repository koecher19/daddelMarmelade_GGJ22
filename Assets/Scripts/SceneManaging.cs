using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public GameObject sceneChangeTrigger;

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
        var sceneTransitions = new List<(string thisScene, string nextScene)>
        {
            ("6-Sidescroller", "7-Sidescroller"),
            ("7-Sidescroller", "TextAdventure"),
            ("10-Sidescroller", "11-Sidescroller"),
            ("11-Sidescroller", "12-Sidescroller"),
            ("12-Sidescroller", "TextAdventure"),
            ("15-Sidescroller", "16-Sidescroller"),
            ("16-Sidescroller", "TextAdventure")
        };

        if (trig.gameObject.tag == "sceneChangeTrigger")
        {
            foreach (var tupel in sceneTransitions)
            {
                if(tupel.thisScene == SceneManager.GetActiveScene().name)
                {
                    SceneManager.LoadScene(tupel.nextScene);
                }
            }
            
        }
    }
}
