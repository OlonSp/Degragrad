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

    private void Awake()
    {
        foreach (CoeffUI cf in coefficients)
        {
            coeffs[cf.name] = cf;
            cf.targetHeight = targetFlagHeight;
            cf.smooth = heightSmooth;
        }
    }

    public void SetDefaultValues()
    {
        foreach (CoeffUI cf in coeffs.Values)
        {
            cf.percents = 50;
        }
    }

    public bool ChangeValue(string key, float delta)
    {
        if (coeffs.ContainsKey(key)) coeffs[key].ChangePercents(delta);
        if (coeffs[key].percents == 0 || coeffs[key].percents == 100)
        {
            switch (key)
            {
                case "imba":
                    break;
                case "goblin":
                    break;
                case "key":
                    break;
                case "money":
                    break;
                
            }
        }
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
        coeffs[coeffName].targetHeight = selectedFlagHeight;
    }

    void Start()
    {
        SetDefaultValues();
    }
}
