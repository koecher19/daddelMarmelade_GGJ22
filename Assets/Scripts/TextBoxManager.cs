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
    private List<StoryBlock> storyBlocks  = new List<StoryBlock>();
    private int storyBlockObjectCount = 0;
    public GameObject buttonManager;
    private ButtonManager buttonManagerScript;
    private GameObject leftButtonGameObjectReference;
    private GameObject rightButtonGameObjectReference;
    private GameObject continueButtonGameObjectReference;
    public int currentScene = 0;
    public int displayedScene = 0;
    private int updateCount = 0;
    private int updateMethodCount = 0;
    private int updateMethodSuccessCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        buttonManagerScript = buttonManager.GetComponent<ButtonManager>();

        // load lines form txt file into array:
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));

            // if no endAtLine is defined: end at last line in txt-file
            if (endAtLine == 0)
            {
                endAtLine = textLines.Length - 1;
            }

            int tempSceneNumber;            //}
            string tempStorytext;           //} 
            string tempLeftButtonText;      //}
            string tempRightButtonText;     //}temporary values to create listObjects with
            int tempLeftButtonNextScene;    //}
            int tempRightButtonNextScene;   //}
            bool tempDecision;              //} 
            int tempCharakterNumber;     //} 
            int tempEventNumber;     //} 
            int tempMusicEventNumber;     //}
            while (currentLine<endAtLine)
            {
                //takes up the number which indicates the scenenumber
                Debug.Log(storyBlockObjectCount + " tempscenenumber string:" + textLines[currentLine]);
                Debug.Log(storyBlockObjectCount + " tempscenenumber int:" + int.Parse(textLines[currentLine]));
                tempSceneNumber = int.Parse(textLines[currentLine]);
                //takes up the Story which is to be displayed on the main text.
                Debug.Log(storyBlockObjectCount + " tempStoryText string:" + textLines[currentLine+1]);
                tempStorytext = textLines[currentLine + 1];
                //takes the string which indicates the Text displayed on the left button 
                Debug.Log(storyBlockObjectCount + " tempLeftButonText string:" + textLines[currentLine + 2]);
                tempLeftButtonText = textLines[currentLine + 2];
                //takes the string which indicates the Text displayed on the right button                                                                       
                Debug.Log(storyBlockObjectCount + " tempRightButonText string:" + textLines[currentLine + 3]);
                tempRightButtonText = textLines[currentLine + 3];
                //takes up the number indicating the next scene when the left Button is pressed.
                Debug.Log(storyBlockObjectCount + " tempLeftButonNextScene string:" + textLines[currentLine+4]);
                string tempLeftCompareString = textLines[currentLine + 4];
                char tempLeftCompareToChar = 'x';
                bool tempLeftButtonBoolean = tempLeftCompareString.StartsWith(tempLeftCompareToChar);
                Debug.Log(storyBlockObjectCount + " tempLeftButonNextScene bool:" + tempLeftButtonBoolean);
                if (tempLeftButtonBoolean)
                    tempLeftButtonNextScene = tempSceneNumber + 1;
                else
                {
                    Debug.Log(storyBlockObjectCount + " tempLeftButonNextScene int:" + int.Parse(textLines[currentLine + 4]));
                    tempLeftButtonNextScene = int.Parse(textLines[currentLine + 4]);
                }
                //takes up the number indicating the next scene when the right Button is pressed.
                Debug.Log(storyBlockObjectCount + " tempRightButonNextScene string:" + textLines[currentLine + 5]);
                string tempRightCompareString = textLines[currentLine + 5];
                char tempRightCompareToChar = 'x';
                bool tempRightButtonBoolean = tempRightCompareString.StartsWith(tempRightCompareToChar);
                Debug.Log(storyBlockObjectCount + " tempRightButonNextScene bool:" + tempLeftButtonBoolean);
                if (tempRightButtonBoolean)
                    tempRightButtonNextScene = tempSceneNumber + 1;
                else
                {
                    Debug.Log(storyBlockObjectCount + " tempRightButonNextScene int:" + int.Parse(textLines[currentLine + 5]));
                    tempRightButtonNextScene = int.Parse(textLines[currentLine + 5]);
                }
                //takes up the boolean which indicates if a decision should be made
                Debug.Log(storyBlockObjectCount + " tempDecision string:" + textLines[currentLine + 6]);
                string tempDecisionCompareString = textLines[currentLine + 6];
                char tempDecisionCompareToChar = '1';
                bool tempDecisionBoolean = tempDecisionCompareString.StartsWith(tempDecisionCompareToChar);
                Debug.Log(storyBlockObjectCount + " tempDecision bool:" + tempDecisionBoolean);
                if (tempDecisionBoolean)
                    tempDecision = true;
                else
                    tempDecision = !true;
                Debug.Log(storyBlockObjectCount + " tempDecision bool:" + tempDecision);

                //creates an object from the class Storyblock with the temporary variables and adds said object to the StoryBlockList.
                storyBlocks.Add(new StoryBlock(tempSceneNumber,tempStorytext,tempLeftButtonText,tempRightButtonText,tempLeftButtonNextScene,tempRightButtonNextScene,tempDecision));
                storyBlockObjectCount++;
                // 7 equals tupelnumber
                currentLine += 7;
            }

        }
        // if no endAtLine is defined: end at last line in txt-file
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        leftButtonGameObjectReference = GameObject.Find("leftButton");
        rightButtonGameObjectReference = GameObject.Find("rightButton");
        continueButtonGameObjectReference = GameObject.Find("continueButton");

        updateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        sceneUpdate();


        // if return key is pressed: go to next line
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentScene += 1;
        }

        updateCount++;
    }

    private void sceneUpdate()
    {

        updateMethodCount++;
        if (displayedScene != currentScene)
        {
            updateMethodSuccessCount++;
            updateDisplay();
        }

    }

    public void updateDisplay()
    {

        StoryBlock readingStoryBlock = storyBlocks[currentScene];
        if (readingStoryBlock.getDecision()==true)
        {
            continueButtonGameObjectReference.SetActive(false);
            theText.color = Random.ColorHSV();
            theText.text = readingStoryBlock.getStorytext();
            leftButtonGameObjectReference.SetActive(false);
            rightButtonGameObjectReference.SetActive(false);
            buttonManagerScript.getLeftButtonText().text = readingStoryBlock.getLeftButtonText();
            buttonManagerScript.getRightButtonText().text = readingStoryBlock.getRightButtonText();
            leftButtonGameObjectReference.SetActive(true);
            rightButtonGameObjectReference.SetActive(true);
            displayedScene = currentScene;
        }
        else
        {
            theText.text = readingStoryBlock.getStorytext();
            continueButtonGameObjectReference.SetActive(true);
            leftButtonGameObjectReference.SetActive(false);
            rightButtonGameObjectReference.SetActive(false);
            buttonManagerScript.getLeftButtonText().text = readingStoryBlock.getLeftButtonText();
            buttonManagerScript.getRightButtonText().text = readingStoryBlock.getRightButtonText();
            displayedScene = currentScene;
        }
    }

    public void leftButtonClicked()
    {
        currentScene = storyBlocks[currentScene].getLeftButtonNextScene();
    }

    public void rightButtonClicked()
    {
        currentScene = storyBlocks[currentScene].getRightButtonNextScene();
    }

    public void continueButtonClicked()
    {
        currentScene++;
    }
    public class StoryBlock
    {

        private int sceneNumber;
        private string storytext;
        private string leftButtonText;
        private string rightButtonText;
        private int leftButtonNextScene;
        private int rightButtonNextScene;
        private bool decision;
        public StoryBlock(int pSceneNumber, string pStorytext, string pLeftButtonText, string pRightButtonText, int pLeftButtonNextScene,int pRightButtonNextScene, bool pDecision)
        {
            sceneNumber = pSceneNumber;
            storytext = pStorytext;
            leftButtonText = pLeftButtonText;
            rightButtonText = pRightButtonText;
            leftButtonNextScene = pLeftButtonNextScene;
            rightButtonNextScene = pRightButtonNextScene;
            decision = pDecision;
        }

        public int getSceneNumber()
        {
            return sceneNumber;
        }
        public string getStorytext()
        {
            return storytext;
        }

        public string getLeftButtonText()
        {
            return leftButtonText;
        }

        public string getRightButtonText()
        {
            return rightButtonText;
        }

        public int getLeftButtonNextScene()
        {
            return leftButtonNextScene;
        }

        public int getRightButtonNextScene()
        {
            return rightButtonNextScene;
        }

        public bool getDecision()
        {
            return decision;
        }
    }
}