using System.Collections;
using Sirenix.OdinInspector;
using System.Linq;

[System.Serializable]
public class Condition
{
    [LabelText("����")]
    [ValueDropdown("coeffNames", AppendNextDrawer = true)]
    public string key;

    [LabelText("�������")]
    [ValueDropdown("ConditionVariants", AppendNextDrawer = false)]
    public string condition = "=";

    [LabelText("��������")]
    public string value;

    [LabelText("������")]
    [VerticalGroup("Next")]
    //[ValueDropdown("GetAvailableCards", AppendNextDrawer = true)]
    public CardBase _NextTrue;

    [LabelText("����")]
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