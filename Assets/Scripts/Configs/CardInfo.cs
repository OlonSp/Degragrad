using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ New Empty Card", order = 51)]
public class CardInfo : ScriptableObject
{
    [Header("���� � �����")]
    [SerializeField] private Sprite _Image;
    public bool canBeSpawn;
    [Tooltip("�����, � �������� ����� ����� ����������")]
    public int timeSinceCanBeSpawn = 0;
    [Tooltip("�����, �� ������� ����� ����� ����������")]
    public int timeUntilCanBeSpawn = -1;

    [Header("���� � �������")]
    [SerializeField] private string _description;
    [SerializeField] private string _leftText;
    [SerializeField] private string _rightText;

    public virtual void LeftChoose()
    {
        Debug.Log("Left Parametrs change");
    }

    public virtual void RightChoose()
    {
        Debug.Log("Rigth Parametrs change");
    }

    public Sprite Image => this._Image;

    public string description => this._description;
    public string leftText => this._leftText;
    public string rightText => this._rightText;


}
