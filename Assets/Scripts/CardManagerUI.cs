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
    

    public Transform cardSpawnPoint;
    public Transform cardStartCenterPoint;
    public Transform cardShowCenterPoint;
    public GameObject cardPrefab;
    public GameObject fakeCard;
    private CardUI activeCard;
    public CardInfo[] cards;
    private List<CardInfo> queue = new List<CardInfo>();
    private List<CardUI> spawnedCards = new List<CardUI>();

    void Start()
    {
        StartCoroutine(CreateStartQueue());
    }

    public IEnumerator CreateStartQueue()
    {
        SetQueue();
        for (int i = 0;i<queue.Count;i++)
        {
            yield return new WaitForSeconds(0.1f);
            SoundManagerController.inst.PlaySound("showCard");
            CreateCard(true);
        }
        yield return new WaitForSeconds(1);
        fakeCard.SetActive(true);
        CreateCard();
    }

    public void CreateCard(bool isSpawnOutScreen = false)
    {
        if (spawnedCards.Count > 0 && !isSpawnOutScreen)
        {
            spawnedCards[0].ShowCard();
            ControllerUI.inst.scrollBlockUI.SetText(spawnedCards[0].cardInfo.description);
            spawnedCards.RemoveAt(0);
            return;
        }
        if (queue.Count == 0) SetQueue();
        CardUI newCard = Instantiate(cardPrefab, transform).GetComponent<CardUI>();
        if (isSpawnOutScreen) newCard.transform.position = cardSpawnPoint.position;
        newCard.mainImage.sprite = queue[0].Image;
        newCard.cardStartCenter = cardStartCenterPoint.GetComponent<RectTransform>().anchoredPosition3D;
        newCard.cardShowCenter = cardShowCenterPoint.GetComponent<RectTransform>().anchoredPosition3D;
        newCard.GetComponent<CardUI>().rightText.text = queue[0].leftText;
        newCard.GetComponent<CardUI>().leftText.text = queue[0].rightText;
        newCard.GetComponent<CardUI>().cardInfo = queue[0];
        if (isSpawnOutScreen) spawnedCards.Add(newCard);
        queue.RemoveAt(0);
        if (!isSpawnOutScreen)
        {
            newCard.ShowCard();
            ControllerUI.inst.scrollBlockUI.SetText(newCard.cardInfo.description);
        }
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
