using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditSteuerung : MonoBehaviour
{
    public GameObject creditPanelReference;
    private GameObject ButtonReference;
    public float scrollspeed;

    private float timeOfTravel = 30.0f;
    private float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.creditPanelReference);
        ButtonReference = GameObject.Find("Button");
        startScrolldown();
    }
    /*
    IEnumerator startRoutine()
    {
        yield return new WaitForSecondsRealtime(1);
    }
    */
    public void startScrolldown()
    {
        /*
        ButtonReference.SetActive(false);
        for (float tempy = 0; tempy < 7000; tempy += 0.5f)
        {
            StartCoroutine(startRoutine());
            creditPanelReference.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, tempy);
            //creditPanelReference.transform.position = new Vector3(0,tempy,0);
        }
        */

        StartCoroutine(LerpObject());
    }
    
    // Update is called once per frame
    void Update()
    {
        /*
        while(this.creditPanelReference.GetComponent<RectTransform>().anchoredPosition.y < 7000.0f)
        {
            this.creditPanelReference.GetComponent<RectTransform>().anchoredPosition += new Vector2(0.0f, 1.0f) * this.scrollspeed * Time.deltaTime;
        }
        */
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    /*
    IEnumerator startScroll()
    {

        IEnumerator LerpObject()
        {
            while (currentTime <= timeOfTravel)
            {
                currentTime += Time.deltaTime;
                float normalizedValue = currentTime / timeOfTravel;

                panelRect.anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);
                yield return null;
            }
        }
    }
    */
    IEnumerator LerpObject()
    {
        RectTransform panelRect = this.creditPanelReference.GetComponent<RectTransform>();

        Vector3 startPosition = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 endPosition = new Vector3(0.0f, 7000.0f, 0.0f);

        yield return new WaitForSeconds(1);

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            float normalizedValue = currentTime / timeOfTravel;

            panelRect.anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);
            yield return null;
        }
    }
}
