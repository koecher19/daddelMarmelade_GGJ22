using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableitemScript : MonoBehaviour
{
    public GameObject interactableParent;


    // Start is called before the first frame update
    void Start()
    {
        if (interactableParent.gameObject.name == "WaterBucket")
        {
            // set acid bucket as inactive
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // hover mouse over this object
    void OnMouseOver()
    {
        // if we have a description: display it
        if (this.interactableParent.GetComponent<Interact>().textfiles.Count != 0)
        {
            this.interactableParent.GetComponent<Interact>().textbox.SetActive(true);
        }
    }

    // when you stop hovering the mouse over object
    void OnMouseExit()
    {
        // stop dislplaying description
        if (this.interactableParent.GetComponent<Interact>().textfiles.Count != 0)
        {
            this.interactableParent.GetComponent<Interact>().textbox.SetActive(false);
        }
    }

    // click on item
    void OnMouseDown()
    {
        // use inventory on item
        this.interactableParent.GetComponent<Interact>().useItem();
        if(interactableParent.gameObject.name == "WaterBucket")
        {
            // set acid bucket as active
        }
    }
    
}
