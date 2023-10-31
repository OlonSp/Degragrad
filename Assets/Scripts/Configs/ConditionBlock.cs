using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "ConditionBlock", menuName = "Create Card/ New Condition Block", order = 51)]
public class ConditionBlock : CardBase
{
    [TableList(ShowPaging = true, AlwaysExpanded = true)]
    [LabelText("Условия")]
    public List<Condition> _conditions = new List<Condition>();
}
