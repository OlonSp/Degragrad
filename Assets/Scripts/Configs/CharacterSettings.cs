using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Settings", menuName = "Characters/Settings", order = 51)]
public class CharacterSettings : ScriptableObject
{
    [LabelText("���������")]
    public Character[] characters;
}
