using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersController : MonoBehaviour
{
    private static ManagersController _inst;
    public static ManagersController Instance
    {
        get
        {
            if (_inst == null) _inst = GameObject.Find("[Managers]").GetComponent<ManagersController>();
            return _inst;
        }
    }
    public CardManagerUI CardManager;
}
