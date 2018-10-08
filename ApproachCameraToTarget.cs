using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApproachCameraToTarget : MonoBehaviour
{
    [SerializeField]
    float speed = 0;
    [SerializeField]
    float speedForSize = 0;
    [SerializeField]
    float sizeForOrtoCam = 0;

    static public bool ortoCam;

    void Update ()
    {
		if(Card.selectCard != null)
        {
            Transform target = Card.selectCard.transform;
            transform.position = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                gameObject.GetComponent<Camera>().orthographicSize = 
                    Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, sizeForOrtoCam, 
                    speedForSize * Time.deltaTime);
                ortoCam = true;
                if(gameObject.GetComponent<Camera>().orthographicSize < (sizeForOrtoCam + 0.1f))
                {
                    Card.selectCard = null;
                    Debug.Log(Card.selectCard);
                    return;
                }
            }
        }
	}
}
