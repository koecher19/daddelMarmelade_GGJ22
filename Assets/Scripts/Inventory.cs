using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    /*
     * inventory consists of a list of GameObjects which names are displayed in a textbox
     * use useItem(GameObject i) to remove i from the list
     */

    public List<GameObject> items;      // a list of items you own
    public TMP_Text theText;            // displays text

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: textbox fixed to screenspace

        // write item list in textbox
        displayItems();

        // test if useItem works by pressing escape key
        if (Input.GetKeyDown(KeyCode.Return))
        {
            useItem(this.items[0]);
        }
    }

    public void useItem(GameObject item)
    {
        // remove item from list
        this.items.Remove(item);
        // delete item
        Destroy(item);
    }

    void displayItems()
    {
        // run over all items and collect name
        string names = "";
        foreach (GameObject item in this.items)
        {
            names += "- ";
            names += item.name;
            names += "\n";
        }
        // display
        theText.text = names;
    }
}
