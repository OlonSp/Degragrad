using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoefficientsManagerUI : MonoBehaviour
{
    public CoeffUI[] coefficients;
    private Dictionary<string, CoeffUI> coeffs = new Dictionary<string, CoeffUI>();

    private void Awake()
    {
        foreach (CoeffUI cf in coefficients)
        {
            coeffs[cf.name] = cf;
        }
    }

    public void SetDefaultValues()
    {
        foreach (CoeffUI cf in coeffs.Values)
        {
            cf.percents = 50;
        }
    }

    public void ChangeValue(string key, float delta)
    {
        coeffs[key].percents -= delta;
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

    void Start()
    {
        SetDefaultValues();
    }
}
