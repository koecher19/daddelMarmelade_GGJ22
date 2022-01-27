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

    // specific for this cutscene
    public GameObject eugene;
    public GameObject nimue;
    public GameObject harveyAlive;
    public GameObject harveyDead;
    public GameObject emptyBox;

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
        Debug.Log("routine started");

        // START
        // set player /inventory / main camera inactive:
        this.inventory.SetActive(false);
        this.player.SetActive(false);
        this.mainCamera.SetActive(false);

        // switch to second camera
        this.cutSceneCamera.SetActive(true);

        // display black screen for 1 second
        this.blackScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        this.blackScreen.SetActive(false);


        // SCENE
        this.nimue.SetActive(false);
        this.harveyAlive.SetActive(false);
        yield return new WaitForSeconds(1);

        /*
        Eugene starts the scene: 
        "And now the show REALLY begins! A magic trick you have NEVER seen before! Let Nimue enchant you with her magic! Clear the stage and welcome our master of wizardry: Nimue!"
        */
        eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
        yield return new WaitForSeconds(1);
        eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        yield return new WaitForSeconds(1);

        /*
        NOTE: ->Black screen(some step sounds) or whatever and Nimue is on stage (maybe Harvey auch schon in der Box -noch lebend)
        */

        /*
        Nimue standing in front of the box with Harvey in it:
        "What if I tell you that you can make two men out of one? Would you want that?"
        */

        /*
        NOTE: Währenddessen sollte Harvey sowas sagen wie: 
        “Oh, there is more space in here than usual.You guys took a long time to do that, haha.”
        */

        /*
        NOTE: -> Publikum be like ahaha wuhuuu aahhh
        */

        /*
        Nimue again:
        "So, let me show you my new trick!"
        */

        /*
        NOTE: -> schwarzer bildschirm und danach sägt Nimue die Person auseinander:
         */

        /*
        "And now let's pull this man apart. And you see the wonder!"
        NOTE: -> Die Animation mit Blut und so
         */

        yield return new WaitForSeconds(1);

        // END
        // display black screen for 1 second
        this.blackScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        this.blackScreen.SetActive(false);

        // switch back to main camera
        this.cutSceneCamera.SetActive(false);

        // set player /inventory / main camera active:
        this.mainCamera.SetActive(true);
        this.inventory.SetActive(true);
        this.player.SetActive(true);

        // distory the cutScene trigger
        Destroy(gameObject);
    }
}
