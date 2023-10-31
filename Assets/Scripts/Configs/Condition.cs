using System.Collections;
using Sirenix.OdinInspector;
using System.Linq;

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
}