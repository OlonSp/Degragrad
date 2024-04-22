using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class CardManagerUI : MonoBehaviour
{
    //[System.Serializable]
    //public class Person
    //{
    //    public Sprite sprite;
    //    public int countInQueue;
    //}

    [SerializeField] private Text DescriptionText;
    
    [SerializeField]
    private Transform CardSpawnPoint;
    [SerializeField]
    private Transform CardStartCenterPoint;
    [SerializeField]
    private Transform CardShowCenterPoint;
    [SerializeField]
    private GameObject CardPrefab;
    [SerializeField]
    private GameObject FakeCard;
    [HideInInspector]
    public CardUI activeCard;
    [HideInInspector]
    public List<CardUI> spawnedCards = new List<CardUI>();
    [HideInInspector]
    public int currentCardNum;
    [HideInInspector]
    public CardBase spawnDeath = null;
    private bool isDeathSpawned;
    [SerializeField]
    private StandartCard EmptyCard;

    public ConditionBlock[] MainBlockConditions;
    public StandartCard[] SideCards;
    public Vector2 SideCardsCountBounds;
    private bool _isMainQuest = true;
    private List<StandartCard> _sideQueue = new List<StandartCard>();

    void Start()
    {
        ControllerUI.inst.blackScreen.animEnded += OnDeathScreenShow;
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

    public void NewShowCard()
    {
        if (!spawnDeath)
        {
            CardBase newCard = SelectNewCard();
            ShowCard(newCard, false);
        }
        else
        {
            ShowCard(spawnDeath, false);
        }
    }

    public CardBase SelectNewCard()
    {
        CardBase newCard = null;
        if (_isMainQuest)
        {
            foreach (ConditionBlock block in MainBlockConditions)
            {
                newCard = block.GetHextCard();
                if (newCard != null) break;
            }
            _isMainQuest = !_isMainQuest;
        }
        if (newCard == null)
        {
            if (_sideQueue.Count == 0)
            {
                int sideCount = (int)UnityEngine.Random.Range(SideCardsCountBounds.x, SideCardsCountBounds.y);
                _sideQueue = SideCards.OrderBy(arg => Guid.NewGuid()).Take(sideCount).ToList();
            }
            newCard = _sideQueue[0];
            _sideQueue.RemoveAt(0);
            if (_sideQueue.Count == 0)
            {
                _isMainQuest = true;
            }
        }
        return newCard;
    }

    public IEnumerator CreateStartQueue()
    {
        for (int i = 0;i<10;i++)
        {
            yield return new WaitForSeconds(0.1f);
            SoundManagerController.inst.PlaySound("showCard0");
            ShowCard(EmptyCard, true);
        }
        yield return new WaitForSeconds(2);
        FakeCard.SetActive(true);
        foreach (CardUI card in spawnedCards)
        {
            Destroy(card.gameObject);
        }
        spawnedCards.Clear();
        ShowNextCard();
    }
    
    public void OnDeathScreenShow()
    {
        ControllerUI.inst.wideBackImg.GetComponent<Image>().sprite = ControllerUI.inst.curDeathBackground;
        ControllerUI.inst.SetTheme("death");
        FakeCard.SetActive(false);
    }

    public void ShowNextCard()
    {
        if (isDeathSpawned) return;
        NewShowCard();
    }

    public void ShowCard(CardBase card, bool isSpawnOutScreen)
    {
        if ((card as CardInfo) != null)
        {
            SpawnCard(card as CardInfo, isSpawnOutScreen);
        }
        else if ((card as ConditionBlock) != null)
        {
            CardBase newCard = (card as ConditionBlock).GetHextCard();
            if (newCard != null) ShowCard(newCard, isSpawnOutScreen);
        }
    }

    public void SpawnCard(CardInfo card, bool isSpawnOutScreen)
    {
        CardUI newCard = Instantiate(CardPrefab, transform).GetComponent<CardUI>();
        if (isSpawnOutScreen) newCard.transform.position = CardSpawnPoint.position;
        newCard.mainImage.sprite = card.Image;
        newCard.cardStartCenter = CardStartCenterPoint.GetComponent<RectTransform>().anchoredPosition3D;
        newCard.cardShowCenter = CardShowCenterPoint.GetComponent<RectTransform>().anchoredPosition3D;
        newCard.GetComponent<CardUI>().rightText.text = card.leftText;
        newCard.GetComponent<CardUI>().leftText.text = card.rightText;
        newCard.GetComponent<CardUI>().cardInfo = card;
        if (isSpawnOutScreen) spawnedCards.Add(newCard);
        if (newCard.cardInfo.GetType() == typeof(DeathCard))
        {
            ControllerUI.inst.blackScreen.Show();
        }
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
}
