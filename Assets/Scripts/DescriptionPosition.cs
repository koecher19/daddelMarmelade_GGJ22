using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionPosition : MonoBehaviour
{
    public GameObject itemSprite;
    public GameObject stupidPanel;
    public float descriptionHeight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stupidPanel.activeSelf)
        {
            // Move the object to the same position as the interactable sprite
            Vector3 spritePos = itemSprite.transform.position;
            /*
            // get size of sprite
            float itemHeigth = itemSprite.GetComponent<SpriteRenderer>().bounds.size.y;
            */
            //var panelHeigth = stupidPanel.GetComponent<RectTransform>().sizeDelta;
            transform.position = new Vector3(spritePos.x, descriptionHeight, spritePos.z);
        }
    }
}
