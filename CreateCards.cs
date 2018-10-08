using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateCards : MonoBehaviour, IPointerClickHandler
{
    Object Card;
    Object Shirt;
    public GameObject panelForCards;

    GameObject card;

    void Awake ()
    {
        Card = Resources.Load("Card");
        Shirt = Resources.Load("Shirt");

        CreatedCards();
	}
	
    void CreatedCards()
    {
        for(int i = 0; i < 6; i++)
        {
            // Создаём карту
            card = Instantiate(Card) as GameObject;
            card.name = "card " + (1 + i);
            card.transform.SetParent(panelForCards.transform);
            card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            card.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            //card.GetComponent<RectTransform>().rotation = new Quaternion(0, -180, 0, 0);
            // Паддинг топ 0
            card.GetComponent<UnityEngine.UI.VerticalLayoutGroup>().padding = new RectOffset(0, 0, 0, 0);
            // Добавляем рубашку
            GameObject shirt = Instantiate(Shirt) as GameObject;
            shirt.transform.SetParent(card.transform);
            shirt.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            shirt.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            CardsAreLiving.cards[i] = card;
        }
    }

    

    public void OnPointerClick(PointerEventData eventData)
    {
         card.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
    }
}
