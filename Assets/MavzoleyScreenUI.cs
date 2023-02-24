using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class MavzoleyScreenUI : MonoBehaviour
{
    public Transform tablesRoot;
    public TableRowUI[] tableRowTemplates;
    public bool isDataLoaded;
    private List<TableRowUI> tableRows = new List<TableRowUI>();

    private void Start()
    {
        Web.OnDataLoaded += LoadData;
        LoadData();
    }

    public void LoadData()
    {
        string jsonString = Web.me.GetData("DonateInfo");
        if (jsonString == "") return;

        JSONNode data = JSON.Parse(jsonString)["data"];

        foreach (JSONNode donate in data["donations"])
        {
            bool isItemAdded = false;
            if (tableRows.Count > 0)
            {
                isItemAdded = tableRows[tableRows.Count - 1].SetTableData(donate["donator_info"]["name"].Value, donate["amount"].AsInt.ToString());
            }
            if (!isItemAdded)
            {
                TableRowUI newRowPref;
                if (tableRows.Count <= tableRowTemplates.Length - 1)
                {
                    newRowPref = tableRowTemplates[tableRows.Count];
                }
                else
                {
                    newRowPref = tableRowTemplates[3];
                }
                TableRowUI newRow = Instantiate(newRowPref.gameObject, tablesRoot).GetComponent<TableRowUI>();
                newRow.gameObject.SetActive(true);
                tableRows.Add(newRow);
                newRow.SetTableData(donate["donator_info"]["name"].Value, donate["amount"].AsInt.ToString());
            }
        }
    }
}
