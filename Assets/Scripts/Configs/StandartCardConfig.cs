using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ Standart card", order = 51)]
public class StandartCardConfig : CardInfo
{
    [System.Serializable]
    public class Parametrs
    {
        [Tooltip("Ключи: imba, goblin, key, money")]
        public string key;
        public float value;
    }

    public Parametrs[] _leftParametrsToChange;
    public Parametrs[] _rightParametrsToChange;

    public override void LeftChoose()
    {
        Debug.Log("Left Parametrs change");
        foreach(var i in _leftParametrsToChange)
        {
            ControllerUI.inst.coeffManager.ChangeValue(i.key, i.value);
        }

    }

    public override void RightChoose()
    {
        Debug.Log("Rigth Parametrs change");

        foreach (var i in _rightParametrsToChange)
        {
            ControllerUI.inst.coeffManager.ChangeValue(i.key, i.value);
        }
    }
}
