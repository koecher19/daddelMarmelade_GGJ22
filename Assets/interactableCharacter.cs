using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableCharacter : MonoBehaviour
{
    public GameObject interactableParent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // hover mouse over this object
    void OnMouseOver()
    {
        // if we have a dialog: display it
        if (this.interactableParent.GetComponent<Interact>().description != null)
        {
            this.interactableParent.GetComponent<Interact>().textbox.SetActive(true);
        }
    }

    // when you stop hovering the mouse over object
    void OnMouseExit()
    {
        // stop dislplaying dialog
        if (this.interactableParent.GetComponent<Interact>().description != null)
        {
            this.interactableParent.GetComponent<Interact>().textbox.SetActive(false);
        }
    }

    // click on character
    void OnMouseDown()
    {
        // use inventory on item
        this.interactableParent.GetComponent<Interact>().nextDialog();
    }

}