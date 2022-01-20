using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    /* loads individual lines from a txt-file into an array
     * displays them seperately as text in a textbox
     * display next line by pressing return-key
     * souce: https://www.youtube.com/watch?v=ehmBIP5sj0M
     */
    public GameObject textBox;  // contains text display
    public TMP_Text theText;    // displays text
    public TextAsset textFile;  // txt-file caintains whole text
    public string[] textLines;  // array which stores individual lines
    public int currentLine;     // currently displayed line (index in array)
    public int endAtLine;       // set to last line you want to display

    // Start is called before the first frame update
    void Start()
    {
        // load lines form txt file into array:
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        // if no endAtLine is defined: end at last line in txt-file
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // display current line
        theText.text = textLines[currentLine];

        // if return key is pressed: go to next line
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine += 1;
        }
        // if we reach last text line: stop displaying
        if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
        }
    }
}