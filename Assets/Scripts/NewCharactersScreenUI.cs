using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharactersScreenUI : MonoBehaviour
{
    [SerializeField] private CharacterSettings characterSettings;
    [SerializeField] private Transform blockParent;
    [SerializeField] private CharacterUI characterPref;
    private bool _isDataLoaded = false;

    public System.Action<Character> OnCharacterSelected;

    private void OnEnable()
    {
        LoadData();
    }

    public void LoadData()
    {
        if (_isDataLoaded) return;
        foreach (Character chr in characterSettings.characters)
        {
            CharacterUI newChar = Instantiate(characterPref, blockParent) as CharacterUI;
            newChar.SetData(chr);
            newChar.OnBtnClick += CharacterSelected;
        }
        _isDataLoaded = true;
    }

    public void CharacterSelected(Character character)
    {
        OnCharacterSelected?.Invoke(character);
    }
}
