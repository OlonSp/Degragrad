using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ New Style Empty Card", order = 51)]
public class NewCardInfo : ScriptableObject
{
    [LabelText("Изображение")]
    [SerializeField] private Sprite _Image;
}
