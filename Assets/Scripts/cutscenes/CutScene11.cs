using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene11 : MonoBehaviour
{
    public GameObject inventory;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject blackScreen;
    public GameObject cutSceneCamera;

    private float blackoutTime = 0.5f;

    // for this specific scene:
    public GameObject eugene;
    public GameObject sunshine;
    public GameObject flower;
    public GameObject bucket;

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

        // display black screen for 1 second
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }



        // SCENE
        /*
        NOTE: ->Eugene sagt:
        "After the tragic death of Harvey the last show - let us have one moment to celebrate what he died for..."
        */
        // preparations:
        {
            this.flower.SetActive(false);
            this.sunshine.SetActive(false);

            this.bucket.SetActive(true);
            this.eugene.SetActive(true);
        }

        yield return new WaitForSeconds(1);

        //action:
        {
            // eugene dialog:
            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            yield return new WaitForSeconds(1);
        }



        /*
        NOTE: ->Maybe schwarzer Bildschirm und dann geht es weiter, so als "Pause für den Tod"
        */
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(2);
            this.blackScreen.SetActive(false);
        }



        /*
        Eugene: "It is time. Last time the clown Sunshine made the best out of that terrible, terrible situation. And now, let us welcome her again! She will do her best to even top what she did last time! Applause for Sunshine!"
        */
        //action:
        {
            // nächster eugene dialog:
            yield return new WaitForSeconds(1);

            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();

            yield return new WaitForSeconds(1);

            this.eugene.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            yield return new WaitForSeconds(1);

        }



        /*
        NOTE: ->Blackscreen und Sunshine steht da und sagte erstmal, diese paar Witze:
            "What do you call bears with no ears?"
            "B."
            "What do you call a farm that makes bad jokes?"
            "Corny."
            “Who’s there?”
            “Interrupting Cow.”
            “interrupting c-”
            “MOO!”
        */
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }

        // preparation:
        {
            this.eugene.SetActive(false);
            this.sunshine.SetActive(true);
        }

        // action:
        {
            yield return new WaitForSeconds(1);

            // "What do you call bears with no ears?"
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            // "B."
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(2);

            // "What do you call a farm that makes bad jokes?"
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            // "Corny."
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(2);

            // “Who’s there?”
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            //  “Interrupting Cow.”
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            // “interrupting c-”
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            //this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();

            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            // “MOO!”
            //this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }

        /*
        NOTE: -> Publikum buht langsam
        "What do you call a fake noodle?"
        "An impasta."
        */
        //action
        {
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);


            //"What do you call a fake noodle?"
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();


            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            //"An impasta."
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();


        }

        /*
        NOTE: -> Sunshine whispering to herself:
        "So you want a tired clown? One that you can laugh at?"
        */
        {
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            //"So you want a tired clown? One that you can laugh at?"
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }
        /*
        NOTE: -> Erzähler Line:
        "Oh, that is not your choice."
        */

        /*
        “Did you hear about the guy who invented the knock-knock joke ?”
        “He won the no-bell prize.”
        */
        {
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            //“Did you hear about the guy who invented the knock-knock joke ?”
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();


            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            //“He won the no-bell prize.”
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }

        /*
        NOTE: -> Blackscreen, Sunshine richtet Blume auf sich selber
        */
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }


        /*
        NOTE: -> Blume macht splash, splash, Säure, Säure
        */
        //preparation:
        this.flower.SetActive(true);

        /*
        NOTE: -> Sunshine screm, screm - Publikum Whuup whuup
        Publikum lines: “This is amazing! I have to tell my friends!”
        “Wow! This show! The others won’t believe me!”
        “Unbelievable!”
        */
        {
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            //  "aaa AAAAA"
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();


            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().nextDialog();
            yield return new WaitForSeconds(1);

            //"AAAAAAAAAAAA”
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(2);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }



        /*
        NOTE: -> Sunshine rennt zu Eimer, im Eimer mehr Säure
        */
        // preparation:
        this.flower.SetActive(false);
        
        // action:
        {
            this.blackScreen.SetActive(true);
            yield return new WaitForSeconds(blackoutTime);
            this.blackScreen.SetActive(false);
        }

        {
            // reposition sunshine:
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<Transform>().position += Vector3.left * 2.0f + Vector3.up * 0.2f;
            //"AAAAAAAAAAAA”
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().showDialog();
            yield return new WaitForSeconds(1);
            this.sunshine.transform.GetChild(1).gameObject.GetComponent<SceneCharacter>().stopDialog();
        }


        yield return new WaitForSeconds(2);



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

        // whats left:
        this.sunshine.SetActive(false);
        this.flower.SetActive(true);
        this.flower.GetComponent<Transform>().position += Vector3.down * 2.0f;

        // distory the cutScene trigger
        Destroy(gameObject);
    }
}
