using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create Card/ New Death Card", order = 51)]
public class DeathCard : CardInfo
{
    [HideInInspector]
    [SerializeField] private int _indexOfSceneOnLeft;
    [HideInInspector]
    [SerializeField] private int _indexOfSceneOnRigth;

    public override void LeftChoose()
    {
        ModelController.SetDefaults();
        SceneManager.LoadScene(_indexOfSceneOnLeft);
    }

    public override void RightChoose()
    {
        ModelController.SetDefaults();
        SceneManager.LoadScene(_indexOfSceneOnRigth);
    }
}

