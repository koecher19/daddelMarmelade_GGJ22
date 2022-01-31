using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skskskss : MonoBehaviour
{
    public AudioSource spspspspsp;
    public bool spriteActive;
    public bool wasSpriteActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.spriteActive = gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled;
        if(this.wasSpriteActive != this.spriteActive)
        {
            this.spspspspsp.Play();
            this.wasSpriteActive = true;
        }
    }

}
