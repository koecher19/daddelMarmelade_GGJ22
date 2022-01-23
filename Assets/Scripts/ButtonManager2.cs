using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ButtonManager2")]
public class ButtonManager2 : ScriptableObject
{

    public Button leftButton;
    private Text lButTRef;
    public Button rightButton;
    private Text rButTRef;
    public GameObject textBoxManager;
    private TextBoxManager textBoxManagerScript;
    private int tempInt;
    private string tempString;
    private int tempcurrentline;
    private int tempendline;
    // Start is called before the first frame update
    public void Awake()
    {
        //textBoxManager = GameObject.Find("TextBoxManager");
        textBoxManagerScript = textBoxManager.GetComponent<TextBoxManager>();
        lButTRef = leftButton.GetComponentInChildren<Text>();
        rButTRef = rightButton.GetComponentInChildren<Text>();

    }

    public void Update()
    {
        tempendline = textBoxManagerScript.endAtLine;
        tempcurrentline = textBoxManagerScript.currentLine;
    }

    public void LeftButtonClicked()
    {
        textBoxManagerScript.currentLine = getNextStoryblockNumber(3) * 5;
    }

    public void RightButtonClicked()
    {
        textBoxManagerScript.currentLine = getNextStoryblockNumber(4) * 5;
    }

    public Text getLeftButtonText()
    {
        return lButTRef;
    }
    public Text getRightButtonText()
    {
        return lButTRef;
    }

    public int getNextStoryblockNumber(int decisionnumber)
    {
        tempInt = textBoxManagerScript.currentLine + decisionnumber;
        tempString = textBoxManagerScript.textLines[tempInt];
        return System.Convert.ToInt32(tempString);
    }
}
