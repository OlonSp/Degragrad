using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ New Death Card", order = 51)]
public class DeathCard : CardInfo
{

    [SerializeField] private int _indexOfSceneOnLeft;
    [SerializeField] private int _indexOfSceneOnRigth;

    public override void LeftChoose()
    {
        SceneManager.LoadScene(_indexOfSceneOnLeft);
    }

    public override void RightChoose()
    {
        SceneManager.LoadScene(_indexOfSceneOnRigth);
    }
}

