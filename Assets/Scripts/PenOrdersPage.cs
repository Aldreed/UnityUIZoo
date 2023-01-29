using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PenOrdersPage : MonoBehaviour
{
    [SerializeField] private GameObject GM;
    [SerializeField] private GameObject OrderPrefab;
    [SerializeField] private Transform Content;


    public void initPage()
    {


        List<PendingOrders> tempList = GM.GetComponent<MainDB>().getPenOrders();

        foreach (PendingOrders item in tempList)
        {
            GameObject n = Instantiate(OrderPrefab, Content);
            TMP_Text mtext = n.GetComponentInChildren<TMP_Text>();
            mtext.text = "User: " + item.User + " Order: " + item.OrderType + " Quantity: " + item.NumOfOrder;

            if (item.Reviewed)
            {
                Button b = n.GetComponentInChildren<Button>();
                b.interactable = false;
                b.GetComponentInChildren<TMP_Text>().text = "Approved";
            }
            PenOrderButton pob = n.GetComponent<PenOrderButton>();
            pob.CurOrder = item;
            pob.GM = GM;

        }
    }

}
