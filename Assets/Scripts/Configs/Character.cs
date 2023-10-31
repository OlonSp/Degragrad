using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Character", menuName = "Characters/Create Character", order = 51)]
public class Character : ScriptableObject
{
    [LabelText("Изображение")]
    public Sprite _image;
    [LabelText("Имя")]
    public string _name;
    [TextArea(12, 99)]
    [LabelText("Описание")]
    public string _description;
}
