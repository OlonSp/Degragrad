using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoefficientsManagerUI : MonoBehaviour
{
    public CoeffUI[] coefficients;
    private Dictionary<string, CoeffUI> coeffs = new Dictionary<string, CoeffUI>();

    public float targetFlagHeight;
    public float selectedFlagHeight;
    public float heightSmooth;

    private bool _isInit;
    private void Awake()
    {
        Init();
    }

    public void SetValues()
    {
        foreach (CoeffUI cf in coeffs.Values)
        {
            cf.SetPercents(ModelController.GetCoeff(cf.coeffKey));
        }
    }

    public void ResetDefaultValues()
    {
        Init();
        foreach (CoeffUI cf in coeffs.Values)
        {
            ModelController.SetCoeff(cf.coeffKey, 50);
        }
        SetValues();
    }

    public void Init()
    {
        if (_isInit) return;
        foreach (CoeffUI cf in coefficients)
        {
            coeffs[cf.name] = cf;
            cf.targetHeight = targetFlagHeight;
            cf.smooth = heightSmooth;
        }
        _isInit = true;
    }

    public bool ChangeValue(string key, float delta)
    {
        if (coeffs.ContainsKey(key)) coeffs[key].ChangePercents(delta);
        //if (coeffs[key].percents == 0 || coeffs[key].percents == 100)
        //{
        //    switch (key)
        //    {
        //        case "imba":
        //            break;
        //        case "goblin":
        //            break;
        //        case "key":
        //            break;
        //        case "money":
        //            break;
                
        //    }
        //}
        return coeffs.ContainsKey(key);
    }

    public IEnumerator PreviewCoeffs()
    {
        for (int i = 0;i<coefficients.Length;i++)
        {
            yield return new WaitForSeconds(2);
            coefficients[i].SetPercents(50 + (i + 1) * 10);
        }
        for (int i = 0; i < coeffs.Count; i++)
        {
            yield return new WaitForSeconds(2);
            coefficients[i].SetPercents(50 - (i + 1) * 10);
        }
    }

    public void DesellectFlags()
    {
        foreach (CoeffUI coeff in coefficients) coeff.targetHeight = targetFlagHeight;
    }

    public void SelectFlag(string coeffName)
    {
        if (!coeffs.ContainsKey(coeffName)) return;
        coeffs[coeffName].targetHeight = selectedFlagHeight;
    }

    void Start()
    {
        SetValues();
    }
}
