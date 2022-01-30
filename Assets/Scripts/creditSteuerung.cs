using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditSteuerung : MonoBehaviour
{
    private GameObject creditPanelReference;
    private GameObject ButtonReference;
    // Start is called before the first frame update
    void Start()
    {
        creditPanelReference = GameObject.Find("creditSchriftPanel");
        ButtonReference = GameObject.Find("Button");


    }

    IEnumerator startRoutine()
    {
        yield return new WaitForSecondsRealtime(1);
    }
    public void startScrolldown()
    {
        ButtonReference.SetActive(false);
        for (float tempy = 0; tempy < 7000; tempy += 0.5f)
        {
            StartCoroutine(startRoutine());
            creditPanelReference.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, tempy);
            //creditPanelReference.transform.position = new Vector3(0,tempy,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
