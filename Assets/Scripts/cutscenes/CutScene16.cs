using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene16 : MonoBehaviour
{
    public GameObject inventory;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject blackScreen;
    public GameObject cutSceneCamera;

    private float blackoutTime = 0.5f;

    // specific for this scene:
    public GameObject eugene;
    public GameObject celeste;
    public GameObject avery;
    public GameObject tatjana;
    public GameObject pesto;


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

        // display black screen
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }

        // SCENE
        /*
        Eugene: “Another day, another show! This time two of our greatest stars enter the stage! Take a step back, because you can hear them roar - Get yourself ready for Avery and Celeste!”
        yield return new WaitForSeconds(1);
        */

        /*
        NOTE: -> Avery und Celeste kommen Anklagend auf die Bühne
        Avery: “No, EUGENE. Stay on stage for a moment for one moment.”
        */

        /*
        NOTE: -> Eugene verwirrt und schwitzend, bleibt aber auf der Bühne 
        Avery: “This trick is for you, the one man destroying everything. The root of all the bad things happening. No more Changes! Celeste…”
        Avery: “You know what to do.”
        Celeste: “Tatjana, Pesto. Let's go, it's playtime!”
        */

        /*
        NOTE: -> Tiger spielen mit Eugene und seinen Körperteilen
        NOTE: -> Eugene wird von Tigern zerfetzt - Publikum sagt, ja, wuhu, sie wollen mehr davon (Also mehr spektakuläre Tode)
        NOTE: -> Avery und/oder Celeste reagieren auf Publikum, like wtf
        Avery: “No matter how much you cheer, with his death all of this should end soon!”
        */

        /*
        NOTE: -> Avey umarmt Celeste
        Avery: “Celeste we did it, we never will lose someone ag…”
        */

        /*
        NOTE:  -> Avery gets the bullet in da head (auflackernder roter Bildschirm for le shooting)
        */

        /*
        NOTE: -> Celeste am Ende, kniet weinend neben der in ihren Armen gestorbenen Avery
        */

        /*
        NOTE: -> Publikum zufrieden, whup whup
        */

        // END
        // display black screen for 1 second
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

        // distory the cutScene trigger
        Destroy(gameObject);
    }
}
