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
        if (trig.gameObject.tag == "sceneChangeTrigger")
        {
            Debug.Log("hit scene change trigger");
            SceneManager.LoadScene("TextAdventure");
        }
    }
}
