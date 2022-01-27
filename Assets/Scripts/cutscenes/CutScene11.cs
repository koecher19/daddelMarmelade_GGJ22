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
        // do lots of stuff
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
