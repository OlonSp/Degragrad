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
    public CardUI activeCard;
    public CardInfo[] cards;
    private List<CardInfo> queue = new List<CardInfo>();
    public List<CardUI> spawnedCards = new List<CardUI>();
    public int currentCardNum;
    public bool spawnDeath = false;
    private bool isDeathSpawned;

    void Start()
    {
        ControllerUI.inst.blackScreen.animEnded += OnDeathScreenShow;
    }

    private void Update()
    {
        
    }

    public void MoveCardToLeft()
    {
        if (activeCard != null)
        {
            activeCard.MoveToLeft();
        }
    }

    public void MoveCardToRight()
    {
        if (activeCard != null)
        {
            activeCard.MoveToRight();
        }
    }

    public void SpawnCards()
    {
        StartCoroutine(CreateStartQueue());
    }

    public IEnumerator CreateStartQueue()
    {
        SetQueue();
        for (int i = 0;i<queue.Count;i++)
        {
            yield return new WaitForSeconds(0.1f);
            SoundManagerController.inst.PlaySound("showCard0");
            CreateCard(true);
        }
        yield return new WaitForSeconds(1);
        fakeCard.SetActive(true);
        CreateCard();
    }
    
    // Показ экрана смерти
    public void OnDeathScreenShow()
    {
        ControllerUI.inst.wideBackImg.GetComponent<Image>().sprite = ControllerUI.inst.curDeathBackground;
        ControllerUI.inst.SetTheme("death");
        fakeCard.SetActive(false);
    }

    public void CreateCard(bool isSpawnOutScreen = false)
    {
        if (isDeathSpawned) return;
        if (spawnedCards.Count > 0 && !isSpawnOutScreen)
        {
            currentCardNum += 1;
            spawnedCards[0].ShowCard();
            activeCard = spawnedCards[0];
            ControllerUI.inst.scrollBlockUI.SetText(spawnedCards[0].cardInfo.description);
            spawnedCards.RemoveAt(0);
            return;
        }
        if (queue.Count == 0)
        {
            SetQueue();
        }
        CardUI newCard = Instantiate(cardPrefab, transform).GetComponent<CardUI>();
        if (isSpawnOutScreen) newCard.transform.position = cardSpawnPoint.position;
        newCard.mainImage.sprite = queue[0].Image;
        newCard.cardStartCenter = cardStartCenterPoint.GetComponent<RectTransform>().anchoredPosition3D;
        newCard.cardShowCenter = cardShowCenterPoint.GetComponent<RectTransform>().anchoredPosition3D;
        newCard.GetComponent<CardUI>().rightText.text = queue[0].leftText;
        newCard.GetComponent<CardUI>().leftText.text = queue[0].rightText;
        newCard.GetComponent<CardUI>().cardInfo = queue[0];
        if (isSpawnOutScreen) spawnedCards.Add(newCard);
        if (newCard.cardInfo.GetType() == typeof(DeathCard))
        {
            ControllerUI.inst.blackScreen.Show();
        }
        queue.RemoveAt(0);
        if (!isSpawnOutScreen)
        {
            if (!spawnDeath)
            {
                activeCard = newCard;
                newCard.ShowCard();
                currentCardNum += 1;
                ControllerUI.inst.scrollBlockUI.SetText(newCard.cardInfo.description);
            }
            else
            {
                StartCoroutine(ShowCardWithDelay(newCard));
            }
        }
    }

    public IEnumerator ShowCardWithDelay(CardUI newCard)
    {
        yield return new WaitForSeconds(0.1f);
        newCard.ShowCard();
        isDeathSpawned = true;
        ControllerUI.inst.scrollBlockUI.SetText(newCard.cardInfo.description);
    }

    public void AddCardToQueue(CardInfo newCard)
    {
        queue.Insert(0, newCard);
    }

    public void ClearQueue()
    {
        queue.Clear();
        if (spawnedCards.Count > 1)
        {
            for (int i = 0; i < spawnedCards.Count; i++)
            {
                Destroy(spawnedCards[i].gameObject);
            }
            spawnedCards = new List<CardUI>() { spawnedCards[0] };
        }
    }

    public void SetQueue()
    {
        foreach (CardInfo card in cards)
        {
            if(card.canBeSpawn == true && ModelController.monthsCount >= card.timeSinceCanBeSpawn && (card.timeUntilCanBeSpawn == -1  || ModelController.monthsCount <= card.timeUntilCanBeSpawn ))
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
