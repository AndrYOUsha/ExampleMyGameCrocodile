using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Animator anim;
    RectTransform rTransform;

    Vector3[] directions = new Vector3[6];

    static public int blockClick = 0;
    bool isMovement;

    static public GameObject selectCard;

    [SerializeField]
    float speed = 0;
    [SerializeField]
    Vector2 newTargetByX;
    [SerializeField]
    Vector2 newTargetByY;

    private void Start()
    {
        rTransform = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (ReturnOnBegin.isChecked)
        {
            isMovement = false;
        }
        if (isMovement && ApproachCameraToTarget.ortoCam)
        {
            Movement();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (blockClick < 1)
        {
            rTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        else
            rTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rTransform.localScale = new Vector3(1f, 1f, 1f);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        // тут я чекаю булевую переменную из класса RetirnOnBegin в надежде остановить разлетающиеся карты, но тщетно
        // я устал на сегодня
        if (!ReturnOnBegin.isChecked)
        {
            if (blockClick < 1)
            {
                anim.SetInteger("Click", 1);
                rTransform.localScale = new Vector3(1f, 1f, 1f);
                blockClick++;
                selectCard = gameObject;
                gameObject.transform.parent.GetComponent<GridLayoutGroup>().enabled = false;

                NewTargetForCard();
            }
        }
    }

    void NewTargetForCard()
    {
        for (int i = 0; i < CardsAreLiving.cards.Length; i++)
        {
            if (gameObject != CardsAreLiving.cards[i])
            {
                #region Conditions
                if ((gameObject.GetComponent<RectTransform>().anchoredPosition.y ==
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.y) &&
                    (gameObject.GetComponent<RectTransform>().anchoredPosition.x >
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.x))
                {
                    //Debug.Log(CardsAreLiving.cards[i] + ": " + "y == y && x > x");
                    directions[i] = CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition - newTargetByX;
                }
                else if ((gameObject.GetComponent<RectTransform>().anchoredPosition.y ==
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.y) &&
                    (gameObject.GetComponent<RectTransform>().anchoredPosition.x <
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.x))
                {
                    //Debug.Log(CardsAreLiving.cards[i] + ": " + "y == y && x < x");
                    directions[i] = CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition + newTargetByX;
                }
                else if ((gameObject.GetComponent<RectTransform>().anchoredPosition.x ==
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.x) &&
                    (gameObject.GetComponent<RectTransform>().anchoredPosition.y >
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.y))
                {
                    //Debug.Log(CardsAreLiving.cards[i] + ": " + "x == x && y > y");
                    directions[i] = CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition - newTargetByY;
                }
                else if ((gameObject.GetComponent<RectTransform>().anchoredPosition.x ==
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.x) &&
                    (gameObject.GetComponent<RectTransform>().anchoredPosition.y <
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.y))
                {
                    //Debug.Log(CardsAreLiving.cards[i] + ": " + "x == x && y < y");
                    directions[i] = CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition + newTargetByY;
                }
                else if ((gameObject.GetComponent<RectTransform>().anchoredPosition.x >
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.x) &&
                    (gameObject.GetComponent<RectTransform>().anchoredPosition.y <
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.y))
                {
                    //Debug.Log(CardsAreLiving.cards[i] + ": " + "x > x && y < y");
                    directions[i] = CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition - newTargetByX + newTargetByY;
                }
                else if ((gameObject.GetComponent<RectTransform>().anchoredPosition.x >
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.x) &&
                    (gameObject.GetComponent<RectTransform>().anchoredPosition.y >
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.y))
                {
                    //Debug.Log(CardsAreLiving.cards[i] + ": " + "x > x && y > y");
                    directions[i] = CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition - newTargetByX - newTargetByY;
                }
                else if ((gameObject.GetComponent<RectTransform>().anchoredPosition.x <
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.x) &&
                    (gameObject.GetComponent<RectTransform>().anchoredPosition.y >
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.y))
                {
                    //Debug.Log(CardsAreLiving.cards[i] + ": " + "x < x && y > y");
                    directions[i] = CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition + newTargetByX - newTargetByY;
                }
                else if ((gameObject.GetComponent<RectTransform>().anchoredPosition.x <
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.x) &&
                    (gameObject.GetComponent<RectTransform>().anchoredPosition.y <
                    CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition.y))
                {
                    //Debug.Log(CardsAreLiving.cards[i] + ": " + "x < x && y > y");
                    directions[i] = CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition + newTargetByX + newTargetByY;
                }
                #endregion
                //Debug.Log("card" + (1 + i) + ": " + CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition);
            }
        }
        isMovement = true;
        //Debug.Log(isMovement);
    }

    void Movement()
    {
        for (int i = 0; i < CardsAreLiving.cards.Length; i++)
        {
            if (gameObject != CardsAreLiving.cards[i])
            {
                CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp
                (CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition,
                directions[i],
                speed * Time.deltaTime);

                if (Vector3.Distance
                    (CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition, directions[i])
                    < 5)
                {
                    isMovement = false;
                    ApproachCameraToTarget.ortoCam = false;
                    //Debug.Log(isMovement);
                    //Debug.Log("card" + (1 + i) + ": " + CardsAreLiving.cards[i].GetComponent<RectTransform>().anchoredPosition);

                }
            }
        }
    } 

    public void ClickFalse(int off)
    {
        anim.SetInteger("Click", 0);
    }
    
    
}
