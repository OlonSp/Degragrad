using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private Image image;

    public System.Action<Character> OnBtnClick;
    private Character _data;

    public Sprite _image { set => image.sprite = value; }
    public string _label { get => label.text; set => label.text = value; }

    public void SetData(Character character)
    {
        _data = character;
        _image = _data._image;
        _label = _data._name;
    }

    public void BtnClick()
    {
        OnBtnClick?.Invoke(_data);
    }
}
