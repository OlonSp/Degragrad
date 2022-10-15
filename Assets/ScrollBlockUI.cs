using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollBlockUI : MonoBehaviour
{
    public TMP_Text text;
    public string targetText;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetText(string newText)
    {
        targetText = newText;
        animator.Rebind();
        animator.Play("TextChange", 0);
    }

    public void OnTextChange()
    {
        text.text = targetText;
    }
}
