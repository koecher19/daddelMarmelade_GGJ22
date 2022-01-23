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
    public List<StoryBlock> storyBlockList;
    public int currentLine;     // currently displayed line (index in array)
    public int endAtLine;       // set to last line you want to display
    public GameObject buttonManager;
    private ButtonManager buttonManagerScript;
    public int currentScene = 0;
    public int displayedScene = 0;
    private int storyBlockObjectCount = 0;


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
            while(currentLine<endAtLine)
            {
                //   tempSceneNumber = System.Convert.ToInt32(textLines[currentLine]);
                //   tempStorytext = textLines[currentLine + 1];
                //tempLeftButtonText = textLines[currentLine + 2];
                //tempRightButtonText = textLines[currentLine + 3];
                //tempLeftButtonNextScene = System.Convert.ToInt32(textLines[currentLine+4]);
                //tempRightButtonNextScene = System.Convert.ToInt32(textLines[currentLine+5]);
                tempSceneNumber = 0;
                tempStorytext = textLines[currentLine + 1];
                tempLeftButtonText = textLines[currentLine + 2];
                tempRightButtonText = textLines[currentLine + 3];
                tempLeftButtonNextScene = 1;
                tempRightButtonNextScene = 2;
                if (textLines[currentLine + 6].Equals("1"))
                    tempDecision = true;
                else
                    tempDecision = !true;
                storyBlockList.Add(new StoryBlock(storyBlockObjectCount,tempStorytext,tempLeftButtonText,tempRightButtonText,tempLeftButtonNextScene,tempRightButtonNextScene,tempDecision));
                storyBlockObjectCount++;
            }

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
        sceneUpdate();


        // if return key is pressed: go to next line
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine += 7;
        }

        // if we reach last text line: stop displaying
        if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
        }
    }

    private void sceneUpdate()
    {
        if(displayedScene != currentScene)
        {
            StoryBlock readingStoryBlock = storyBlockList[currentScene];
            if (readingStoryBlock.getDecision())
            {
                GameObject.Find("continueButton").SetActive(false);
                theText.text = readingStoryBlock.getStorytext();
                buttonManagerScript.getLeftButtonText().text = readingStoryBlock.getLeftButtonText();
                buttonManagerScript.getRightButtonText().text = readingStoryBlock.getRightButtonText();
                GameObject.Find("leftButton").SetActive(true);
                GameObject.Find("rightButton").SetActive(true);
            }
            else
            {
                GameObject.Find("continueButton").SetActive(true);
                GameObject.Find("leftButton").SetActive(false);
                GameObject.Find("rightButton").SetActive(false);
                buttonManagerScript.getLeftButtonText().text = readingStoryBlock.getLeftButtonText();
                buttonManagerScript.getRightButtonText().text = readingStoryBlock.getRightButtonText();
            }

        }

    }

    public void leftButtonClicked()
    {
        currentScene = storyBlockList[currentScene].getLeftButtonNextScene();
    }

    public void rightButtonClicked()
    {
        currentScene = storyBlockList[currentScene].getRightButtonNextScene();
    }

    public void middleButtonClicked()
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
            return sceneNumber;
        }

        public int getRightButtonNextScene()
        {
            return sceneNumber;
        }

        public bool getDecision()
        {
            return decision;
        }
    }
}