using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ New Empty Card", order = 51)]
public class CardInfo : ScriptableObject
{
    [Title("���������� � �����")]
    [LabelText("�����������")]
    [SerializeField] private Sprite _Image;
    [LabelText("������ (���./����.)")]
    public bool canBeSpawn;
    [LabelText("�����, � �������� ����� ����� ����������")]
    public int timeSinceCanBeSpawn = 0;
    [LabelText("�����, �� ������� ����� ����� ����������")]
    public int timeUntilCanBeSpawn = -1;

    [Title("���������� � �������")]
    [LabelText("����� �������")]
    [SerializeField] private string _description;
    [LabelText("����� �����")]
    [SerializeField] private string _leftText;
    [LabelText("����� ������")]
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
