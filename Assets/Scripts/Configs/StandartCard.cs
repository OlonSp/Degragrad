using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ New Standart Card", order = 51)]
public class StandartCard : CardInfo
{

    [System.Serializable]
    public class Parametrs
    {
        [ValueDropdown("coeffNames", AppendNextDrawer = true)]
        [LabelText("����")]
        public string key;
        [LabelText("��������")]
        public string value;

        private string[] coeffNames = { "imba", "goblin", "key", "money" };
    }

    [Title("����� �����")]
    [LabelText("��������� ��� ���������")]
    public Parametrs[] _leftParametrsToChange;
    [LabelText("����� ��������� �����")]
    public CardInfo[] _newCardOnLeft;
    [LabelText("����� ��� ��������")]
    public CardInfo[] _cardsToDeleteLeft;
    [LabelText("��������� �����")]
    [ValueDropdown("GetAvailableCards", AppendNextDrawer = true)]
    public CardInfo _nextCardLeft;
    [LabelText("�������� ������ (�������� ��� ����� ����� ������)")]
    public bool _changeSpawnL;

    [Title("����� ������")]
    [LabelText("��������� ��� ���������")]
    public Parametrs[] _rightParametrsToChange;
    [LabelText("����� ��������� �����")]
    public CardInfo[] _newCardOnRight;
    [LabelText("����� ��� ��������")]
    public CardInfo[] _cardsToDeleteRight;
    [LabelText("��������� �����")]
    [ValueDropdown("GetAvailableCards", AppendNextDrawer = true)]
    public CardInfo _nextCardRight;
    [LabelText("�������� ������ (�������� ��� ����� ����� ������)")]
    public bool _changeSpawnR;
#if UNITY_EDITOR
    private IEnumerable GetAvailableCards()
    {
        return UnityEditor.AssetDatabase.FindAssets("t:CardInfo")
            .Select(x => UnityEditor.AssetDatabase.GUIDToAssetPath(x))
            .Select(x => new ValueDropdownItem(UnityEditor.AssetDatabase.LoadAssetAtPath<CardInfo>(x).description, UnityEditor.AssetDatabase.LoadAssetAtPath<CardInfo>(x)));
    }
#endif
    public void ParseParameters(Parametrs[] parametrs)
    {
        foreach (var i in parametrs)
        {
            int value = 0;
            if (int.TryParse(i.value, out value))
            {
                if (!ControllerUI.inst.coeffManager.ChangeValue(i.key, value))
                {
                    PlayerPrefs.SetString(i.key, i.value);
                }
            }
            else
            {
                PlayerPrefs.SetString(i.key, i.value);
            }

        }
    }

    public override void LeftChoose()
    {
        ParseParameters(_leftParametrsToChange);
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
        ParseParameters(_rightParametrsToChange);
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
