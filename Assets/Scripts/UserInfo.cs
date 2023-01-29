using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{

    public enum UserType
    {
        Worker,
        Visitor
    }

    private string name;
    private string surname;
    private string phoneNum;
    private string username;
    private string address;
    private string email;
    private UserType userType;
    private List<NotificationInfo> notificationInfos = new List<NotificationInfo>();
    private int unreadNotifications = 0;

    public int UreadNotifications
    {
        get { return unreadNotifications; }
        set { unreadNotifications = value; }
    }

    public List<NotificationInfo> NotificationInfos
    {
        get { return notificationInfos; }
        set { notificationInfos = value; }
    }

    public UserType UType
    {
        get { return userType; }
        set { userType = value; }
    }


    public string Email
    {
        get { return email; }
        set { email = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }


    public string Phone
    {
        get { return phoneNum; }
        set { phoneNum = value; }
    }

    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }


}
