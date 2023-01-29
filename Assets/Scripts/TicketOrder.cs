using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketOrder
{
    private string orderType;
    private int orderNum;

    public int OrderNum
    {
        get { return orderNum; }
        set { orderNum = value; }
    }

    public string OrderType
    {
        get { return orderType; }
        set { orderType = value; }
    }

}
