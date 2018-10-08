using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnOnBegin : MonoBehaviour
{
    Vector3 beginTarget;

    [SerializeField]
    GameObject panel;
    [SerializeField]
    float speed = 0;
    float ortoSize;

    static public bool isChecked;

    private void Awake()
    {
        beginTarget = transform.position;
        ortoSize = transform.GetComponent<Camera>().orthographicSize;
        panel = GameObject.FindGameObjectWithTag("Panel");

        Debug.Log(beginTarget);
    }

    private void Update()
    {
        if (isChecked)
        {
            ReturnCamera();
            if (Vector3.Distance(transform.position, beginTarget) < 0.1f)
            {
                isChecked = false;
                Card.blockClick = 0;
                Debug.Log(isChecked);
            }
        }
    }

    void ReturnCamera()
    {
        transform.position = Vector3.Lerp(transform.position, beginTarget, speed * Time.deltaTime);
        transform.GetComponent<Camera>().orthographicSize = 
            Mathf.Lerp(transform.GetComponent<Camera>().orthographicSize, ortoSize, speed * Time.deltaTime);
        panel.GetComponent<GridLayoutGroup>().enabled = true;

        //Debug.Log(beginTarget);
        //Debug.Log("I here!");
    }

    public void IsChacked()
    {
        if(Card.selectCard == null)
            isChecked = true;
    }
}
