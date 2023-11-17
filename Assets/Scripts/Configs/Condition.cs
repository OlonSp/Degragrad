using System.Collections;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Condition
{
    [LabelText("Ключ")]
    [ValueDropdown("coeffNames", AppendNextDrawer = true)]
    public string key;

    [LabelText("Условие")]
    [ValueDropdown("ConditionVariants", AppendNextDrawer = false)]
    public string condition = "=";

    [LabelText("Значение")]
    public string value;

    [LabelText("Истина")]
    [VerticalGroup("Next")]
    //[ValueDropdown("GetAvailableCards", AppendNextDrawer = true)]
    public CardBase _NextTrue;

    [LabelText("Ложь")]
    [VerticalGroup("Next")]
    //[ValueDropdown("GetAvailableCards", AppendNextDrawer = true)]
    public CardBase _NextFalse;

    private string[] coeffNames = { "imba", "goblin", "key", "money" };
    private string[] ConditionVariants = { "=", ">", ">=", "<", "<=" };
    private IEnumerable GetAvailableCards()
    {
        return UnityEditor.AssetDatabase.FindAssets("t:CardInfo")
            .Select(x => UnityEditor.AssetDatabase.GUIDToAssetPath(x))
            .Select(x => new ValueDropdownItem(UnityEditor.AssetDatabase.LoadAssetAtPath<CardInfo>(x).description, UnityEditor.AssetDatabase.LoadAssetAtPath<CardInfo>(x)));
    }

    public bool _IsValid
    {
        get
        {
            int valueInt;
            int dictValueInt = ModelController.TryGetIntValue(key, int.MaxValue);
            string dictValueString = ModelController.TryGetStringValue(key, int.MaxValue.ToString());
            bool useIntValue = dictValueInt != int.MaxValue;
            bool useStrValue = dictValueString != int.MaxValue.ToString();
            if (!useIntValue && !useStrValue) return false;
            bool isValueInt = int.TryParse(value, out valueInt);
            if (condition != "=" && (!useIntValue || !isValueInt)) return false;
            Debug.Log($"{dictValueInt} {valueInt} {useIntValue} {isValueInt}");
            switch (condition)
            {
                case "=":
                    if (useIntValue)
                    {
                        if (isValueInt)
                        {
                            return valueInt == dictValueInt;
                        }
                        return dictValueInt.ToString() == value;
                    }
                    return value == dictValueString;
                case "<=":
                    return dictValueInt <= valueInt;
                case ">=":
                    return dictValueInt >= valueInt;
                case "<":
                    return dictValueInt < valueInt;
                case ">":
                    return dictValueInt > valueInt;
            }
            return false;
        }
    }
}