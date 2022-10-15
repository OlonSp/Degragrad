using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    public static int startYear = 1941;
    public static int yearsCount;
    public static int monthsCount;
    
    public static void ChangeMonths(int delta)
    {
        monthsCount += delta;
        if (monthsCount >= 12)
        {
            monthsCount = 0;
            yearsCount += 1;
        }
        ControllerUI.inst.bottomMenu.yearCounter.SetNumber((yearsCount + startYear).ToString());
        ControllerUI.inst.bottomMenu.SetMonths(monthsCount);
    }
}
