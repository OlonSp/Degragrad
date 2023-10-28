using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ New Empty Card", order = 51)]
public class CardInfo : ScriptableObject
{
    [Title("Информация о карте")]
    [LabelText("Изображение")]
    [SerializeField] private Sprite _Image;
    [LabelText("Статус (вкл./выкл.)")]
    public bool canBeSpawn;
    [LabelText("Месяц, с которого карта может спавниться")]
    public int timeSinceCanBeSpawn = 0;
    [LabelText("Месяц, по который карта может спавниться")]
    public int timeUntilCanBeSpawn = -1;

    [Title("Информация о просьбе")]
    [LabelText("Текст просьбы")]
    [SerializeField] private string _description;
    [LabelText("Текст слева")]
    [SerializeField] private string _leftText;
    [LabelText("Текст справа")]
    [SerializeField] private string _rightText;

    public virtual void LeftChoose()
    {
        Debug.Log("Left Parametrs change");
    }

    public virtual void RightChoose()
    {
        Debug.Log("Rigth Parametrs change");
    }

    public Sprite Image => this._Image;

    public string description => this._description;
    public string leftText => this._leftText;
    public string rightText => this._rightText;


}
