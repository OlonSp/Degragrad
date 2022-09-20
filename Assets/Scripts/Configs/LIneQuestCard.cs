using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ Line Quest card", order = 51)]
public class LIneQuestCard : CardInfo
{
    [SerializeField] private CardInfo _nextCard;

    public override void LeftChoose()
    {
        if(_nextCard != null)
        {
            this.canBeSpawn = false;
            _nextCard.canBeSpawn = true;
            
        }
        
    }

    public override void RightChoose()
    {
        Debug.Log("Rigth Parametrs change");
    }
}

