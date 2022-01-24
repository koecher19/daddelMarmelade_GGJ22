using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interact : MonoBehaviour
{
    public GameObject textbox;      // panel
    public TMP_Text description;    // text
    public TextAsset textfile;      // textfile contains description
    public GameObject inventory;    // players inventory
    public List<GameObject> usableItems;

    // Start is called before the first frame update
    void Start()
    {
        // dont display text at beginning
        textbox.SetActive(false);
        description.text = textfile.text;
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

}
