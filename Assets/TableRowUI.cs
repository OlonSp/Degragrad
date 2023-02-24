using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRowUI : MonoBehaviour
{
    public TableItemUI[] tables;

    public bool SetTableData(string username, string count)
    {
        bool isDataSet = false;
        foreach (TableItemUI table in tables)
        {
            isDataSet = table.SetText(username, count);
            if (isDataSet)
            {
                table.gameObject.SetActive(true);
                break;
            }
        }
        return isDataSet;
    }
}
