using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Character", menuName = "Characters/Create Character", order = 51)]
public class Character : ScriptableObject
{
    [LabelText("�����������")]
    public Sprite _image;
    [LabelText("���")]
    public string _name;
    [TextArea(12, 99)]
    [LabelText("��������")]
    public string _description;
}
