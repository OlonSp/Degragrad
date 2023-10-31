using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewCharacterScreenUI : MonoBehaviour
{
    [SerializeField] private TMP_Text description;
    public string _description { get => description.text; set => description.text = value; }
    [SerializeField] private Image image;
    public Sprite _image { set => image.sprite = value; }
    [SerializeField] private TMP_Text charName;
    public string _name { get => charName.text; set => charName.text = value; }
    [SerializeField] private RectTransform descriptionBlock;
    [SerializeField] private RectTransform characterLayout;

    public void SetData(Character character)
    {
        _description = character._description;
        _image = character._image;
        _name = character._name;
    }

    private void OnEnable()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(descriptionBlock);
        LayoutRebuilder.ForceRebuildLayoutImmediate(characterLayout);
    }
}
