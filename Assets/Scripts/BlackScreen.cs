using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BlackScreen : MonoBehaviour
{
    public delegate void DelegateAnimEnded();
    public DelegateAnimEnded animEnded;

    public void OnShowAnimationEnded()
    {
        animEnded?.Invoke();
    }

    public void Show()
    {
        GetComponent<Animator>().Play("ShowBlackScreen", 0);
    }
}
