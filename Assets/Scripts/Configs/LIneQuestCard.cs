using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ Line Quest card", order = 51)]
public class LIneQuestCard : CardInfo
{
    [Header("Ќазвание следующих карточек в цепочке событий")]
    [SerializeField] private string _nameOfNextCardOnLeft;
    [SerializeField] private string _nameOfNextCardOnRigth;

    public override void LeftChoose()
    {
        if (_nameOfNextCardOnLeft != "")
        {
            
            var allCard = Resources.LoadAll<CardInfo>(path: "");
            foreach(var card in allCard)
            {
                if (card.name == _nameOfNextCardOnLeft)
                {
                    card.canBeSpawn = true;
                    this.canBeSpawn = false;
                }
                
            }
            
        }
        
    }

    public override void RightChoose()
    {
        if (_nameOfNextCardOnRigth != "")
        {
            
            var allCard = Resources.LoadAll<CardInfo>(path: "");
            foreach (var card in allCard)
            {
                if (card.name == _nameOfNextCardOnRigth)
                {
                    this.canBeSpawn = false;
                    card.canBeSpawn = true;
                }
                    
            }

        }
    }
}

