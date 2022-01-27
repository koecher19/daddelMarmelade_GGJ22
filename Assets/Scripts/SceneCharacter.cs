using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCharacter : MonoBehaviour
{
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // makes dialog box visible:
    public void showDialog()
    {
        // if we have a dialog: display it
        if (this.parent.GetComponent<Interact>().textfiles.Count != 0)
        {
            this.parent.GetComponent<Interact>().textbox.SetActive(true);
        }
    }
    // makes dialog box invisible
    public void stopDialog()
    {
        // stop dislplaying dialog
        if (this.parent.GetComponent<Interact>().textfiles.Count != 0)
        {
            this.parent.GetComponent<Interact>().textbox.SetActive(false);
        }
    }
    // switches to next dialog in parents textfiles
    public void nextDialog()
    {
        this.parent.GetComponent<Interact>().nextDialog();
    }
}
