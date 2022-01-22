using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject Inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Collectable")
        {
            Debug.Log("trigger detected");
            // put item in inventory
            Inventory.GetComponent<Inventory>().pickItemUp(trig.gameObject);
            // stop displaying item in scene
            trig.gameObject.GetComponent<Renderer>().enabled = false;
            //Destroy(trig.gameObject);

        }
    }
}
