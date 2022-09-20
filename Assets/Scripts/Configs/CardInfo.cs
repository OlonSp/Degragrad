using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ Empty card", order = 51)]
public class CardInfo : ScriptableObject
{
    [Header("Инфа о карте")]
    [SerializeField] private string _id;
    [SerializeField] private Sprite _Image;
    public bool canBeSpawn;

    [Header("Инфа о просьбе")]
    [SerializeField] private string _description;
    [SerializeField] private string _leftText;
    [SerializeField] private string _rightText;

    public virtual void LeftChoose()
    {
        Debug.Log("left Parametrs change");
    }

    public virtual void RightChoose()
    {
        Debug.Log("Rigth Parametrs change");
    }

    public string id => this._id;
    public Sprite Image => this._Image;
    


    public string description => this._description;
    public string leftText => this._leftText;
    public string rightText => this._rightText;


}
