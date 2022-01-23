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

    // hover mouse over this object
    void OnMouseOver()
    {
        // TODO: either dispaly description or use inventory
        textbox.SetActive(true);
    }
    void OnMouseExit()
    {
        // stop dislplaying description
        textbox.SetActive(false);
    }

}
