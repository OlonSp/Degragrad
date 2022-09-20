using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ Standart card", order = 51)]
public class StandartCardConfig : CardInfo
{
    [SerializeField] private string[] _parametersToChange;
    [SerializeField] private int[] _cofChange;

    public override void LeftChoose()
    {
        Debug.Log("Left Parametrs change");
    }

    public override void RightChoose()
    {
        Debug.Log("Rigth Parametrs change");
    }
}
