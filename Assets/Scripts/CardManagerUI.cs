using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CardManagerUI : MonoBehaviour
{
    //[System.Serializable]
    //public class Person
    //{
    //    public Sprite sprite;
    //    public int countInQueue;
    //}

    [SerializeField] private Text DescriptionText;
    

    public GameObject cardPrefab;
    private CardUI activeCard;
    public CardInfo[] cards;
    private List<CardInfo> queue = new List<CardInfo>();

    void Start()
    {
        CreateCard();
    }

    public void CreateCard()
    {
        if (queue.Count == 0) SetQueue();
        CardUI newCard = Instantiate(cardPrefab, transform).GetComponent<CardUI>();
        newCard.mainImage.sprite = queue[0].Image;
        DescriptionText.text = queue[0].description;
        newCard.GetComponent<CardUI>().rightText.text = queue[0].leftText;
        newCard.GetComponent<CardUI>().leftText.text = queue[0].rightText;
        newCard.GetComponent<CardUI>().cardInfo = queue[0];

        queue.RemoveAt(0);
        newCard.ShowCard();
    }

    public void SetQueue()
    {
        foreach (CardInfo card in cards)
        {
            if(card.canBeSpawn == true)
                queue.Add(card);
        }
        queue.Shuffle();
    }

    //public void ShowCard()
    //{
    //    if (cards.Count == 1)
    //    {
    //        if (!cards[0].cardActive) cards[0].ShowCard();
    //        cards.RemoveAt(0);
    //    }
    //    if (cards.Count == 0) return;
    //    if (cards[cards.Count - 1].cardActive)
    //    {
    //        cards.RemoveAt(cards.Count - 1);
    //    }
    //    cards[cards.Count - 1].ShowCard();
    //}
}
