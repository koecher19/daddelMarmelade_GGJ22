using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public Button leftButton;
    private Text lButTRef;
    public Button rightButton;
    private Text rButTRef;
    public Button continueButton;
    public GameObject textBoxManager;
    private TextBoxManager textBoxManagerScript;
    // Start is called before the first frame update
    public void Start()
    {
        textBoxManagerScript = textBoxManager.GetComponent<TextBoxManager>();
        lButTRef = leftButton.GetComponentInChildren<Text>();
        rButTRef = rightButton.GetComponentInChildren<Text>();
    }


    public Text getLeftButtonText()
    {
        return lButTRef;
    }
    public Text getRightButtonText()
    {
        return rButTRef;
    }

}
