using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    // 
    public float maxXPos = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > maxXPos)
        {
            Debug.Log(gameObject.transform.position.x);
            SceneManager.LoadScene("TextAdventure");
        }
    }
}
