using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public CharacterColorReference charakterColors;
    public tACurrentSceneManager tASceneManager;
    public GameObject musicPlayerReference;
    private AudioSource musicPlayer;
    public AudioList audioList;
    public GameObject panelGameObjectReference;
    private GameObject leftButtonGameObjectReference;
    private GameObject rightButtonGameObjectReference;
    private GameObject continueButtonGameObjectReference;
    private GameObject debugButtonManagerGameObjectReference;
    private int leftButtonNextSceneReference;
    private int rightButtonNextSceneReference;   
    public GameObject flyerPanelGameObjectReference;
    public GameObject instructionsPanelGameObjectReference;
    public GameObject middlePanelGameObjectReference;
    public int displayedScene = 0;
    private int updateCount = 0;
    private int updateMethodCount = 0;
    private int updateMethodSuccessCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        buttonManagerScript = buttonManager.GetComponent<ButtonManager>();
        musicPlayer = musicPlayerReference.GetComponent<AudioSource>();

        leftButtonGameObjectReference = GameObject.Find("leftButton");
        rightButtonGameObjectReference = GameObject.Find("rightButton");
        continueButtonGameObjectReference = GameObject.Find("continueButton");
        debugButtonManagerGameObjectReference = GameObject.Find("DebugButtonManager");
        flyerPanelGameObjectReference.SetActive(false);
        debugButtonManagerGameObjectReference.SetActive(tASceneManager.debugEnabled);

        //charakterColors.appointColors();

        // load lines form txt file into array[] and then List<Storyblock>
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
                Debug.Log(storyBlockObjectCount + " tempScenenumber string:" + textLines[currentLine]);
                Debug.Log(storyBlockObjectCount + " tempScenenumber int:" + int.Parse(textLines[currentLine]));
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
                Debug.Log(storyBlockObjectCount + " tempDecisionBool bool:" + tempDecisionBoolean);
                if (tempDecisionBoolean)
                    tempDecision = true;
                else
                    tempDecision = !true;
                Debug.Log(storyBlockObjectCount + " tempDecision bool:" + tempDecision);

                //takes up the number representing the Charakter for recoloring.
                Debug.Log(storyBlockObjectCount + " tempCharakterNumber string:" + textLines[currentLine + 7]);
                Debug.Log(storyBlockObjectCount + " tempCharakterNumber int:" + int.Parse(textLines[currentLine + 7]));
                tempCharakterNumber = int.Parse(textLines[currentLine + 7]);

                //takes up the number indicating if a Event will happen(0 = no) other numbers refer to the event.
                Debug.Log(storyBlockObjectCount + " tempEventNumber string:" + textLines[currentLine + 8]);
                Debug.Log(storyBlockObjectCount + " tempEventNumber int:" + int.Parse(textLines[currentLine + 8]));
                tempEventNumber = int.Parse(textLines[currentLine + 8]);

                //takes up the number indicating if a musical Event will happen(0 = no) other numbers refer to the event.
                Debug.Log(storyBlockObjectCount + " tempMusicEventNumber string:" + textLines[currentLine + 9]);
                Debug.Log(storyBlockObjectCount + " tempMusicEventNumber int:" + int.Parse(textLines[currentLine + 9]));
                tempMusicEventNumber = int.Parse(textLines[currentLine + 9]);

                //creates an object from the class Storyblock with the temporary variables and adds said object to the StoryBlockList.
                storyBlocks.Add(new StoryBlock(tempSceneNumber,tempStorytext,tempLeftButtonText,tempRightButtonText,tempLeftButtonNextScene,tempRightButtonNextScene,tempDecision,tempCharakterNumber,tempEventNumber,tempMusicEventNumber));
                storyBlockObjectCount++;
                // 10 equals tupelnumber
                currentLine += 10;
            }

        }
        // if no endAtLine is defined: end at last line in txt-file
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }


        updateDisplay();
        updateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            tASceneManager.debugEnabled = !tASceneManager.debugEnabled;
            debugButtonManagerGameObjectReference.SetActive(tASceneManager.debugEnabled);
        }
        sceneUpdate();
        updateCount++;
    }

    private void sceneUpdate()
    {
        updateMethodCount++;
        if (displayedScene != tASceneManager.currentScene)
        {
            updateMethodSuccessCount++;
            updateDisplay();
            leftButtonNextSceneReference = storyBlocks[tASceneManager.currentScene].getLeftButtonNextScene();
            rightButtonNextSceneReference = storyBlocks[tASceneManager.currentScene].getRightButtonNextScene();
        }
    }

    public void updateDisplay()
    {
        StoryBlock readingStoryBlock = storyBlocks[tASceneManager.currentScene];
        if (readingStoryBlock.getEventNumber() == 0)
        {
            if (readingStoryBlock.getDecision() == true) //Setup TextAdventure mit Entscheidung
            {
                middlePanelGameObjectReference.SetActive(true);
                flyerPanelGameObjectReference.SetActive(false);
                instructionsPanelGameObjectReference.SetActive(false);
                panelGameObjectReference.SetActive(true);
                checkForMusicEvent(readingStoryBlock.getMusicEventNumber());
                continueButtonGameObjectReference.SetActive(false);
                checkForCharakterNumber(readingStoryBlock.getCharakterNumber());
                theText.text = readingStoryBlock.getStorytext();
                leftButtonGameObjectReference.SetActive(false);
                rightButtonGameObjectReference.SetActive(false);
                buttonManagerScript.getLeftButtonText().text = readingStoryBlock.getLeftButtonText();
                buttonManagerScript.getRightButtonText().text = readingStoryBlock.getRightButtonText();
                leftButtonGameObjectReference.SetActive(true);
                rightButtonGameObjectReference.SetActive(true);
                displayedScene = tASceneManager.currentScene;
            }
            else                                         //Setup TextAdventure ohne Entscheidung
            {
                middlePanelGameObjectReference.SetActive(true);
                flyerPanelGameObjectReference.SetActive(false);
                instructionsPanelGameObjectReference.SetActive(false);
                panelGameObjectReference.SetActive(true);
                checkForMusicEvent(readingStoryBlock.getMusicEventNumber());
                checkForCharakterNumber(readingStoryBlock.getCharakterNumber());
                theText.text = readingStoryBlock.getStorytext();
                continueButtonGameObjectReference.SetActive(true);
                leftButtonGameObjectReference.SetActive(false);
                rightButtonGameObjectReference.SetActive(false);
                buttonManagerScript.getLeftButtonText().text = readingStoryBlock.getLeftButtonText();
                buttonManagerScript.getRightButtonText().text = readingStoryBlock.getRightButtonText();
                displayedScene = tASceneManager.currentScene;
            }
        }
        else
        {
            checkForMusicEvent(readingStoryBlock.getMusicEventNumber());
            checkForEvent(readingStoryBlock.getEventNumber());
        }
    }
                                                                                        
    public void checkForCharakterNumber(int charakterNumber)
    {
        Debug.Log("currentScene:" + tASceneManager.currentScene + "  getCharakterNumber.result: " + charakterNumber);
        if (charakterNumber == 1)       //IN CASE OF NARRATOR
        {
            theText.fontSize = 60;
            theText.fontStyle = FontStyles.Italic;
            theText.color = charakterColors.colors[charakterNumber];
        }
        else
        {
            theText.color = charakterColors.colors[charakterNumber];
            theText.fontStyle = FontStyles.Normal;
            theText.fontSize = 38;
        }
    }

    public void checkForMusicEvent(int musicEventNumber)
    {
        Debug.Log("currentScene:" + tASceneManager.currentScene + "  getMusicEventNumber.result :" + musicEventNumber);
        Debug.Log("currentScene:" + tASceneManager.currentScene + "musicPlayer.clip = audioList.audios[MusicEventNumber];");
        musicPlayer.clip = audioList.audios[musicEventNumber];
        Debug.Log("currentScene:" + tASceneManager.currentScene + "musicPlayer.Play();");
        musicPlayer.Play();
        
            //playMusic...
    }

    //3 --> text to side
    //3 <-- side to text
    public void checkForEvent(int eventNumber)
    {
        Debug.Log("currentScene:" + tASceneManager.currentScene + "  getEventNumber.result" + eventNumber);
        switch (eventNumber)
        {
            case 1:/*Flyer spawns*/
                middlePanelGameObjectReference.SetActive(false);
                leftButtonGameObjectReference.SetActive(false);
                rightButtonGameObjectReference.SetActive(false);
                continueButtonGameObjectReference.SetActive(true);
                flyerPanelGameObjectReference.SetActive(true);
                theText.text = storyBlocks[tASceneManager.currentScene].getStorytext();
                displayedScene = tASceneManager.currentScene;
                break;
            case 2:/*Instruction spawns*/
                middlePanelGameObjectReference.SetActive(false);
                leftButtonGameObjectReference.SetActive(false);
                rightButtonGameObjectReference.SetActive(false);
                continueButtonGameObjectReference.SetActive(true);
                instructionsPanelGameObjectReference.SetActive(true);
                theText.text = storyBlocks[tASceneManager.currentScene].getStorytext();
                displayedScene = tASceneManager.currentScene;
                break;
            case 3:/*transition first Textadvenure -> first sidescroller*/
                tASceneManager.currentScene++;
                SceneManager.LoadScene("6-Sidescroller");
                displayedScene = tASceneManager.currentScene;
                tASceneManager.currentScene = tASceneManager.currentScene;
                break;
            case 4:/*transition second Textadvenure -> third sidescroller*/
                tASceneManager.currentScene++;
                SceneManager.LoadScene("10-Sidescroller");
                displayedScene = tASceneManager.currentScene;
                tASceneManager.currentScene = tASceneManager.currentScene;
                break;
            case 5:/*transition first Textadvenure -> fifth sidescroller*/ break;
            case 6:/*transition first Textadvenure -> fifth sidescroller*/ break;
            case 7:/*transition first Textadvenure -> fifth sidescroller*/ break;
            case 8:/*transition first Textadvenure -> fifth sidescroller*/ break;
            case 9:/*switch first gooddecision*/    tASceneManager.goodChoice1 = true; tASceneManager.currentScene++; break;
            case 10:/*switch second gooddecision*/  tASceneManager.goodChoice2 = true; tASceneManager.currentScene++; break;
            case 11:/*switch third gooddecision*/   tASceneManager.goodChoice3 = true; tASceneManager.currentScene++; break;
            case 12:/*switch fourth gooddecision*/  tASceneManager.goodChoice4 = true; tASceneManager.currentScene++; break;
            case 13:/*switch fifth gooddecision*/   tASceneManager.goodChoice5 = true; tASceneManager.currentScene++; break;
            case 14:/*switch sixth gooddecision*/   tASceneManager.goodChoice6 = true; tASceneManager.currentScene++; break;
            case 15:/*check for SecretGoodEnding*/
                if (tASceneManager.checkGoodChoices()) 
                {
                    tASceneManager.currentScene = 0;  //DIESE ZAHL ÄNDERN ZU ENDING-SCENENZAHL
                } 
                else
                {                                                      
                    //tASceneManager.currentScene = 0;  //Normaler Pfad, wenn man böse war
                                                      //basicaly aufrufen der DisplayScene-Methode 
                    middlePanelGameObjectReference.SetActive(true);
                    flyerPanelGameObjectReference.SetActive(false);
                    panelGameObjectReference.SetActive(true);
                    checkForMusicEvent(storyBlocks[tASceneManager.currentScene].getMusicEventNumber());
                    checkForCharakterNumber(storyBlocks[tASceneManager.currentScene].getCharakterNumber());
                    theText.text = storyBlocks[tASceneManager.currentScene].getStorytext();
                    continueButtonGameObjectReference.SetActive(true);
                    leftButtonGameObjectReference.SetActive(false);
                    rightButtonGameObjectReference.SetActive(false);
                    buttonManagerScript.getLeftButtonText().text = storyBlocks[tASceneManager.currentScene].getLeftButtonText();
                    buttonManagerScript.getRightButtonText().text = storyBlocks[tASceneManager.currentScene].getRightButtonText();
                    displayedScene = tASceneManager.currentScene;
                } 
                break;
        }
    }

    public void leftButtonClicked()
    {
        tASceneManager.currentScene = storyBlocks[tASceneManager.currentScene].getLeftButtonNextScene();
    }

    public void rightButtonClicked()
    {
        tASceneManager.currentScene = storyBlocks[tASceneManager.currentScene].getRightButtonNextScene();
    }

    public void continueButtonClicked()
    {
        tASceneManager.currentScene = storyBlocks[tASceneManager.currentScene].getLeftButtonNextScene();
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
        private int charakterNumber;
        private int eventNumber;
        private int musicEventNumber;
        public StoryBlock(int pSceneNumber, string pStorytext, string pLeftButtonText, string pRightButtonText, int pLeftButtonNextScene,int pRightButtonNextScene, bool pDecision, int pCharakterNumber, int pEventNumber, int pMusicEventNumber)
        {
            sceneNumber = pSceneNumber;
            storytext = pStorytext;
            leftButtonText = pLeftButtonText;
            rightButtonText = pRightButtonText;
            leftButtonNextScene = pLeftButtonNextScene;
            rightButtonNextScene = pRightButtonNextScene;
            decision = pDecision;
            charakterNumber = pCharakterNumber;
            eventNumber = pEventNumber;
            musicEventNumber = pMusicEventNumber;
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

        public int getCharakterNumber()
        {
            return charakterNumber;
        }
        public int getEventNumber()
        {
            return eventNumber;
        }
        public int getMusicEventNumber()
        {
            return musicEventNumber;
        }
    }
}