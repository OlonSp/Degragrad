using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ Death card", order = 51)]
public class DeathCard : CardInfo
{
    [SerializeField] private int _indexOfSceneOnLeft;
    [SerializeField] private int _indexOfSceneOnRigth;

    public override void LeftChoose()
    {
        //if (_indexOfSceneOnLeft == null)
        //    return;
        SceneManager.LoadScene(_indexOfSceneOnLeft);
    }

    public override void RightChoose()
    {
        //if (_indexOfSceneOnRigth == null)
        //    return;
        SceneManager.LoadScene(_indexOfSceneOnRigth);
    }
}

