using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interact : MonoBehaviour
{
    public GameObject textbox;              // panel
    public TMP_Text description;            // text
    public List<TextAsset> textfiles;       // textfiles contain dialog
    public GameObject inventory;            // players inventory
    public List<GameObject> usableItems;
    public int dialogIterator = 0;          // iterates over amount of dialog scripts
    public bool isCharacter;

    // Start is called before the first frame update
    void Start()
    {
        // dont display text at beginning
        textbox.SetActive(false);
        
        // if there is dialog
        if (textfiles.Count != 0)
        {
            // set dialog box to fist dialog
            if (isCharacter)
            {
                description.text = gameObject.name + " : \n\n" + textfiles[0].text;
            }
            else
            {
                description.text = textfiles[0].text;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void useItem()
    {
        // check if inventory contains object that is stored as usable item for this object
        // if yes: delete from usableItem list and use item
        foreach(GameObject item in this.usableItems)
        {
            // check if you have a usable item in inventory
            if (inventory.GetComponent<Inventory>().items.Contains(item))
            {
                // if yes: dele item from usableItem list
                this.usableItems.Remove(item);
                // use item on this object
                inventory.GetComponent<Inventory>().useItem(item);
                // to use other item you have to click again
                break;
            }
        }
    }

    public void nextDialog()
    {
        // clicking on character will result in next dialog showing up
        if(dialogIterator < textfiles.Count - 1)
        {
            this.dialogIterator++;

            if (isCharacter)
            {
                description.text = gameObject.name + " : \n" + textfiles[dialogIterator].text;
            }
            else
            {
                description.text = textfiles[0].text;
            }
        }
    }
}

