using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenOrderButton : MonoBehaviour
{
    [SerializeField] private PendingOrders curOrder;
    [SerializeField] private GameObject gm;

    public GameObject GM
    {
        get { return gm; }
        set { gm = value; }
    }

    public PendingOrders CurOrder
    {
        get { return curOrder; }
        set { curOrder = value; }
    }


    public void approveNotification(bool approved)
    {
        NotificationInfo ni = new NotificationInfo();
        if (approved)
        {
            ni.NotificationText = "Order: " + curOrder.OrderType + " Quant: " + curOrder.NumOfOrder + " Was Approved";
        }
        else
        {
            ni.NotificationText = "Order: " + curOrder.OrderType + " Quant: " + curOrder.NumOfOrder + " Was Denied";
        }
        ni.Read = false;
        ni.Date = System.DateTime.Now.ToString("d-M-yyyy");

        gm.GetComponent<MainDB>().addNotification(curOrder.User, ni);
        gm.GetComponent<MainDB>().removeOrder(curOrder);

        Button[] b = this.GetComponentsInChildren<Button>();
        b[0].interactable = false;
        b[1].interactable = false;

    }


}
