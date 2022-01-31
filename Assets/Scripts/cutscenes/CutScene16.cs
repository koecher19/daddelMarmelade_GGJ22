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
    public List<GameObject> eugeneDead;

    public GameObject averyDead;
    public GameObject celesteSad;
    public GameObject redScreen;

    public AudioSource peng;
    public AudioSource geheule;

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

        //die ganzen eugene body parts:
        foreach(GameObject rip in this.eugeneDead)
        {
            rip.SetActive(false);
        }

        // switch to second camera
        this.cutSceneCamera.SetActive(true);

        // display black screen
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }

        //preprarations
        {
            this.avery.SetActive(false);
            this.celeste.SetActive(false);
            this.tatjana.SetActive(false);
            this.pesto.SetActive(false);
            this.averyDead.SetActive(false);
            this.celesteSad.SetActive(false);
            this.redScreen.SetActive(false);
        }

        // SCENE
        /*
        Eugene: “Another day, another show! This time two of our greatest stars enter the stage! Take a step back, because you can hear them roar - Get yourself ready for Avery and Celeste!”
        */
        //action:
        {
            yield return new WaitForSeconds(1);


            // eugene dialog:
            // “Another day, another show! This time two of our greatest stars enter the stage! Take a step back, because you can hear them roar - Get yourself ready for Avery and Celeste!”
            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(10);
            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            yield return new WaitForSeconds(1);

            {
                this.blackScreen.SetActive(true);
                yield return new WaitForSeconds(blackoutTime);
                this.blackScreen.SetActive(false);
            }

            // set eugene a bit to the right:
            this.eugene.transform.GetChild(1).gameObject.GetComponent<Transform>().position += Vector3.right * 4.0f;

            yield return new WaitForSeconds(1);

        }



        /*
        NOTE: -> Avery und Celeste kommen Anklagend auf die Bühne
        Avery: “No, EUGENE. Stay on stage for a moment for one moment.”
        */
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }

        // preparations
        {
            this.celeste.SetActive(true);
            this.avery.SetActive(true);

            this.tatjana.SetActive(true);
            this.pesto.SetActive(true);

            // flip augene:
            this.eugene.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }

        // action
        {
            // No, EUGENE. Stay on stage for a moment for one moment.”
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(4);
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

        }

        /*
        NOTE: -> Eugene verwirrt und schwitzend, bleibt aber auf der Bühne 
        Avery: “This trick is for you, the one man destroying everything. The root of all the bad things happening. No more Changes! Celeste…”
        Avery: “You know what to do.”
        Celeste: “Tatjana, Pesto. Let's go, it's playtime!”
        */

        yield return new WaitForSeconds(2);

        {
            // "..."
            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            yield return new WaitForSeconds(1);

            // “This trick is for you, the one man destroying everything. The root of all the bad things happening. No more Changes! Celeste…”
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(10);
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            // “You know what to do.”
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(4);
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            // “Tatjana, Pesto. Let's go, it's playtime!”
            this.celeste.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(5);
            this.celeste.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }
        yield return new WaitForSeconds(1);



        /*
        NOTE: -> Tiger spielen mit Eugene und seinen Körperteilen
        NOTE: -> Eugene wird von Tigern zerfetzt - Publikum sagt, ja, wuhu, sie wollen mehr davon (Also mehr spektakuläre Tode)
        NOTE: -> Avery und/oder Celeste reagieren auf Publikum, like wtf
        Avery: “No matter how much you cheer, with his death all of this should end soon!”
        */

        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }

        // prepare:
        {
            // eugene lebend ist futsch jetzt
            this.eugene.SetActive(false);
            // eugene leiche
            foreach (GameObject rip in this.eugeneDead)
            {
                rip.SetActive(true);
            }

            // tiggers ändern position:
            //      tatjana:
            this.tatjana.transform.GetChild(1).gameObject.GetComponent<Transform>().position += Vector3.left * 2.5f;
            //      pesto:
            this.pesto.transform.GetChild(1).gameObject.GetComponent<Transform>().position += Vector3.right * 3.5f + Vector3.down * 1.5f;
        }

        // action:
        {
            yield return new WaitForSeconds(2);

            // tatjana sagt rawr weil irgendwo muss ich serotonin her bekommen
            this.tatjana.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(2);
            this.tatjana.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();


            yield return new WaitForSeconds(3);


            // “No matter how much you cheer, with his death all of this should end soon!”
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(6);
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }

        yield return new WaitForSeconds(1);


        /*
        NOTE: -> Avey umarmt Celeste
        Avery: “Celeste we did it, we never will lose someone ag…”
        */
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }

        // preparing
        {
            // avery und celeste ändern position
            this.avery.transform.GetChild(1).gameObject.GetComponent<Transform>().position += Vector3.right * 8.72f;
        }

        // action
        {
            // “Celeste we did it, we never will lose someone ag…”
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(6);
            this.avery.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }

        /*
        NOTE:  -> Avery gets the bullet in da head (auflackernder roter Bildschirm for le shooting)
        */

        // PENG !!!
        {
            this.peng.Play();
            this.redScreen.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            this.redScreen.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            this.redScreen.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            this.redScreen.SetActive(false);
        }

        /*
        NOTE: -> Celeste am Ende, kniet weinend neben der in ihren Armen gestorbenen Avery
        */
        //prepare
        {
            this.celeste.SetActive(false);
            this.avery.SetActive(false);
            this.averyDead.SetActive(true);
            this.celesteSad.SetActive(true);
        }
        yield return new WaitForSeconds(1.0f);
        this.geheule.Play();
        yield return new WaitForSeconds(6.0f);

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
