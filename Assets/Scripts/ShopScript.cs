using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private UserInfo curUser;
    [SerializeField] private GameObject GM;

    [SerializeField] private Toggle Deal1;
    [SerializeField] private Toggle Deal2;
    [SerializeField] private Toggle Deal3;
    [SerializeField] private Toggle Group;
    [SerializeField] private Toggle Single;
    [SerializeField] private TMP_InputField NumOfTicketsForGroup;
    [SerializeField] private TMP_Text notificationText;
    [SerializeField] private GameObject Button;
    [SerializeField] private int Total = 0;
    [SerializeField] private TMP_Text TotalText;
    [SerializeField] private GameObject notificationPopUp;
    [SerializeField] private TMP_InputField PromoCode;


    public void calcTotal()
    {
        if (Group.isOn && NumOfTicketsForGroup.text.Length>0)
        {
            int temp = System.Int32.Parse(NumOfTicketsForGroup.text);
            Total = temp * 100;
        }
        else if (Deal1.isOn)
        {
            Total = 330;
        }
        else if (Deal2.isOn)
        {
            Total = 400;
        }
        else if (Deal3.isOn)
        {
            Total = 600;
        }
        else if (Single.isOn)
        {
            Total = 100;
        }
        else
        {
            Total = 0;
        }

        if (PromoCode.text.Length > 0)
        {
            Total /= 2; 
        }

        TotalText.text = Total.ToString();
    }

    public void turnOff(GameObject o)
    {
        
        if(o.name == "Deal1")
        {

            Deal2.isOn = false;
            Deal3.isOn = false;
            Group.isOn = false;
            Single.isOn = false;
        }
        else if (o.name == "Deal2")
        {

            Deal1.isOn = false;
            Deal3.isOn = false;
            Group.isOn = false;
            Single.isOn = false;
        }
        else if (o.name == "Deal3")
        {

            Deal1.isOn = false;
            Deal2.isOn = false;
            Group.isOn = false;
            Single.isOn = false;
        }
        else if (o.name == "Group")
        {

            Deal1.isOn = false;
            Deal2.isOn = false;
            Deal3.isOn = false;
            Single.isOn = false;
        }
        else if (o.name == "Single")
        {

            Deal1.isOn = false;
            Deal2.isOn = false;
            Deal3.isOn = false;
            Group.isOn = false;
        }

        calcTotal();

    }

    public void checkUser()
    {
        MainDB db = GM.GetComponent<MainDB>();
        curUser = db.getCurUser();

        if (curUser.Address is null || curUser.Address.Length == 0)
        {
            notificationText.text = "You need to enter an adress in the Profile Page ";
            Button.SetActive(false);
        }
        else
        {
            notificationText.text = "";
            Button.SetActive(true);
        }

    }


    public void placeOrder()
    {

        MainDB db = GM.GetComponent<MainDB>();
        curUser = db.getCurUser();

        if(curUser.Address is null ||curUser.Address.Length == 0)
        {
            notificationText.text = "You need to enter an adress in the Profile Page ";
            return;
        }

        if (Deal1.isOn)
        {
            PendingOrders po = new PendingOrders();
            po.NumOfOrder = 1;
            po.OrderType = "Deal1";
            po.User = curUser.Username;

            db.AddPendingRequest(po);
        }
        else if (Deal2.isOn)
        {
            PendingOrders po = new PendingOrders();
            po.NumOfOrder = 1;
            po.OrderType = "Deal2";
            po.User = curUser.Username;

            db.AddPendingRequest(po);
        }
        else if (Deal3.isOn)
        {
            PendingOrders po = new PendingOrders();
            po.NumOfOrder = 1;
            po.OrderType = "Deal3";
            po.User = curUser.Username;

            db.AddPendingRequest(po);
        }
        else if (Group.isOn)
        {
            if (NumOfTicketsForGroup.text.Length <= 0)
            {
                notificationText.text = "Enter the number of tickets you wish to purchase";
                return;
            }

            PendingOrders po = new PendingOrders();

            po.NumOfOrder = System.Int32.Parse(NumOfTicketsForGroup.text);
            po.OrderType = "Group";
            po.User = curUser.Username;

            db.AddPendingRequest(po);
        }
        else if (Single.isOn)
        {
            PendingOrders po = new PendingOrders();
            po.NumOfOrder = 1;
            po.OrderType = "Single";
            po.User = curUser.Username;

            db.AddPendingRequest(po);
        }
        else
        {
            notificationText.text = "Please select your purchase";
            return;
        }


        //notificationText.text = "Order Placed, wait for an Employee to approve your order";
        NumOfTicketsForGroup.text = "";


        Deal1.isOn = false;
        Deal2.isOn = false;
        Deal3.isOn = false;
        Single.isOn = false;
        Group.isOn = false;
        notificationPopUp.SetActive(true);
        notificationPopUp.GetComponent<NotificationPopUp>().showPopUp("Order Placed, wait for an Employee to approve your order");
        
    }

    public void resetForLogOut()
    {
        notificationText.text = "";
        NumOfTicketsForGroup.text = "";
        Deal1.isOn = false;
        Deal2.isOn = false;
        Deal3.isOn = false;
        Single.isOn = false;
        Group.isOn = false;
    }

}
