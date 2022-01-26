using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScript : MonoBehaviour
{
    /*
     * a black screen
     * either to display item or for a cutscene
     * if you can click it away: set button as a child and call deactivate() as onclick()-function
     */

    public bool isClickable;     // if you can click the black screen away or if it leaves by itself

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactivate()
    {
        if (isClickable)
        {
            gameObject.SetActive(false);

        }
    }
}
