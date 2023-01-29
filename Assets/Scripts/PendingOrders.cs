using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PendingOrders
{
    [SerializeField] private string orderType;
    [SerializeField] private int numOfOrder;
    [SerializeField] private string user;
    [SerializeField] private bool reviewed = false;

    public bool Reviewed
    {
        get { return reviewed; }
        set { reviewed = value; }
    }

    public string User
    {
        get { return user; }
        set { user = value; }
    }

    public int NumOfOrder
    {
        get { return numOfOrder; }
        set { numOfOrder = value; }
    }


    public string OrderType
    {
        get { return orderType; }
        set { orderType = value; }
    }

}
