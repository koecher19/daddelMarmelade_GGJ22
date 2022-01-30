using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene7 : MonoBehaviour
{
    public GameObject inventory;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject blackScreen;
    public GameObject cutSceneCamera;

    private float blackoutTime = 0.5f;

    // specific for this cutscene
    public GameObject eugene;
    public GameObject nimue;
    public GameObject harveyAlive;
    public GameObject harveyDead;
    public GameObject emptyBox;
    public GameObject harveyMurder;
    public GameObject harveyMurderFirstFrame;
    public GameObject harveySlice;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject == this.player)
        {
            Debug.Log("start cutscene!");
            StartCoroutine(startRoutine());
        }
    }

    IEnumerator startRoutine()
    {

        // START
        // set player /inventory / main camera inactive:
        this.inventory.SetActive(false);
        this.player.SetActive(false);
        this.mainCamera.SetActive(false);

        // switch to second camera
        this.cutSceneCamera.SetActive(true);

        // display black screen for 1 second
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }


        // SCENE

        /*
        Eugene starts the scene: 
        "And now the show REALLY begins! A magic trick you have NEVER seen before! Let Nimue enchant you with her magic! Clear the stage and welcome our master of wizardry: Nimue!"
        */
        //PREPARATIONS
        {
            this.nimue.SetActive(false);
            this.harveyAlive.SetActive(false);
            this.harveyDead.SetActive(false);
            this.harveyMurder.SetActive(false);
            this.harveyMurderFirstFrame.SetActive(false);
            this.harveySlice.SetActive(false);

            this.emptyBox.SetActive(true);
            this.eugene.SetActive(true);
        }

        yield return new WaitForSeconds(1);


        // ACTION
        {
            // "And now the show REALLY begins! A magic trick you have NEVER seen before! Let Nimue enchant you with her magic! Clear the stage and welcome our master of wizardry: Nimue!"
            eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(10);
            eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }

        yield return new WaitForSeconds(1);



        /*
        NOTE: ->Black screen(some step sounds) or whatever and Nimue is on stage (maybe Harvey auch schon in der Box -noch lebend)
        */
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }


        /*
        Nimue standing in front of the box with Harvey in it:
        "What if I tell you that you can make two men out of one? Would you want that?"
        */

        // PREPARATIONS
        {
            // remove chars objects form last cut:
            this.eugene.SetActive(false);
            this.emptyBox.SetActive(false);

            // new chars/objects
            this.nimue.SetActive(true);
            this.harveyAlive.SetActive(true);
        }

        yield return new WaitForSeconds(1);


        // ACTION
        // dialog
        {

            // "What if I tell you that you can make two men out of one? Would you want that?"
            this.nimue.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(4);
            //this.nimue.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }

        yield return new WaitForSeconds(1);



        /*
        NOTE: Währenddessen sollte Harvey sowas sagen wie: 
        “Oh, there is more space in here than usual.You guys took a long time to do that, haha.”
        */

        // PREPARATIONS

        // ACTION
        {
            // “Oh, there is more space in here than usual.You guys took a long time to do that, haha.”
            this.harveyAlive.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(5);
            this.harveyAlive.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }
        
        yield return new WaitForSeconds(1);



        /*
        NOTE: -> Publikum be like ahaha wuhuuu aahhh
        */


        /*
        Nimue again:
        "So, let me show you my new trick!"
        */

        // PREPARATIONS

        //ACTION
        {
            // "So, let me show you my new trick!"
            this.nimue.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            //this.nimue.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(2.5f);
            this.nimue.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }

        /*
        NOTE: -> schwarzer bildschirm und danach sägt Nimue die Person auseinander:
         */
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }

        // preparations:
        this.harveyAlive.SetActive(false);

        /* harvey auf cuttern mit dem cuttermesser */

        {
            this.harveySlice.SetActive(true);
            yield return new WaitForSeconds(2.8f);
            this.harveySlice.SetActive(false);
        }

        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }



        /*
        "And now let's pull this man apart. And you see the wonder!"
        NOTE: -> Die Animation mit Blut und so
         */

        // PREPARATIONS
        {
            this.harveyAlive.SetActive(false);
            this.harveyMurderFirstFrame.SetActive(true);
        }

        yield return new WaitForSeconds(1);

        // ACTION
        {
            // "And now let's pull this man apart. And you see the wonder!"
            this.nimue.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            this.nimue.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();

            yield return new WaitForSeconds(4);

            this.nimue.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }

        yield return new WaitForSeconds(2);
        {
            this.harveyMurderFirstFrame.SetActive(false);
            this.harveyMurder.SetActive(true);
        }

        yield return new WaitForSeconds(4);



        // END
        // display black screen
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }

        // switch back to main camera
        this.cutSceneCamera.SetActive(false);

        // set player /inventory / main camera active:
        this.mainCamera.SetActive(true);
        this.inventory.SetActive(true);
        this.player.SetActive(true);

        // whats left:
        this.harveyDead.SetActive(true);
        this.nimue.SetActive(false);
        this.harveyMurder.SetActive(false);

        // distory the cutScene trigger
        Destroy(gameObject);
    }
}
