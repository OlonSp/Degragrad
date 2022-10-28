using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ New card", order = 51)]
public class CardInfo : ScriptableObject
{
    [Header("Инфа о карте")]
    //[SerializeField] private string _id;
    [SerializeField] private Sprite _Image;
    public bool canBeSpawn;

    [Header("Инфа о просьбе")]
    [SerializeField] private string _description;
    [SerializeField] private string _leftText;
    [SerializeField] private string _rightText;

    [System.Serializable]
    public class Parametrs
    {
        [Tooltip("Ключи: imba, goblin, key, money")]
        public string key;
        public float value;
    }

    [Header("При свайпе влево")]
    public Parametrs[] _leftParametrsToChange;
    public CardInfo[] _newCardOnLeft;
    public bool _changeSpawnL;

    [Header("При свайпе вправо")]
    public Parametrs[] _rightParametrsToChange;
    public CardInfo[] _newCardOnRight;
    public bool _changeSpawnR;

    public virtual void LeftChoose()
    {
        Debug.Log("left Parametrs change");
        foreach (var i in _leftParametrsToChange)
        {
            ControllerUI.inst.coeffManager.ChangeValue(i.key, i.value);
        }
        foreach (var i in _newCardOnLeft)
        {
            i.canBeSpawn = true;
        }
        if (_changeSpawnL)
        {
            this.canBeSpawn = false;
        }

    }

    public virtual void RightChoose()
    {
        Debug.Log("Rigth Parametrs change");
        foreach (var i in _rightParametrsToChange)
        {
            ControllerUI.inst.coeffManager.ChangeValue(i.key, i.value);
        }
        foreach (var i in _newCardOnRight)
        {
            i.canBeSpawn = true;
        }
        if (_changeSpawnR)
        {
            this.canBeSpawn = false;
        }
    }

    //public string id => this._id;
    public Sprite Image => this._Image;
    


    public string description => this._description;
    public string leftText => this._leftText;
    public string rightText => this._rightText;


}
