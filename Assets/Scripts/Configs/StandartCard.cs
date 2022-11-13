using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ New Standart Card", order = 51)]
public class StandartCard : CardInfo
{

    [System.Serializable]
    public class Parametrs
    {
        [Tooltip("�����: imba, goblin, key, money")]
        public string key;
        public float value;
    }

    [Header("��� ������ �����")]
    public Parametrs[] _leftParametrsToChange;
    public CardInfo[] _newCardOnLeft;
    [Tooltip("�������� ����������� ������ �� ���������������")]
    public bool _changeSpawnL;

    [Header("��� ������ ������")]
    public Parametrs[] _rightParametrsToChange;
    public CardInfo[] _newCardOnRight;
    [Tooltip("�������� ����������� ������ �� ���������������")]
    public bool _changeSpawnR;

    public override void LeftChoose()
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

    public override void RightChoose()
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
}
