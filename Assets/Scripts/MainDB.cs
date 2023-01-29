using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDB : MonoBehaviour
{

    
    
    private UserInfo curUser;

    [SerializeField] private GameObject LogInScreen;

    //Bad security
    //Real products should always use databases && encryption
    [SerializeField] private Hashtable LoginInfos = new Hashtable();
    //Probably should be combined with password
    private Hashtable UserInfos = new Hashtable();
    [SerializeField] private List<AnimalInfo> animalinfos = new List<AnimalInfo>();
    [SerializeField] private List<PendingOrders> penOrders = new List<PendingOrders>();
    [SerializeField] private List<Content> contentList = new List<Content>();



    void Start()
    {
        LoginInfos.Add("basic", "1234");
        LoginInfos.Add("basic1", "2345");
        LoginInfos.Add("basic2", "3456");
        LoginInfos.Add("basic3", "4567");

        UserInfo basic = new UserInfo();
        UserInfo basic1 = new UserInfo();
        UserInfo basic2 = new UserInfo();
        UserInfo basic3 = new UserInfo();

        basic.Username = "basic";
        basic1.Username = "basic1";
        basic2.Username = "basic2";
        basic3.Username = "basic3";

        basic.Email = "nop@noemail.com";
        basic1.Email = "nop1@noemail.com";
        basic2.Email = "nop2@noemail.com";
        basic3.Email = "nop3@noemail.com";

        basic.UType = UserInfo.UserType.Visitor;
        basic1.UType = UserInfo.UserType.Visitor;
        basic2.UType = UserInfo.UserType.Visitor;
        basic3.UType = UserInfo.UserType.Worker;

        basic.Name = "No Name";
        basic1.Name = "No Name1";
        basic2.Name = "No Name2";
        basic3.Name = "No Name3";

        basic.Surname = "No Surname";
        basic1.Surname = "No Surname1";
        basic2.Surname = "No Surname2";
        basic3.Surname = "No Surname3";

        basic.Phone = "1111-2222-3333";
        basic1.Phone = "1111-2222-3333";
        basic2.Phone = "1111-2222-3333";
        basic3.Phone = "1111-2222-3333";

        UserInfos.Add(basic.Username, basic);
        UserInfos.Add(basic1.Username, basic1);
        UserInfos.Add(basic2.Username, basic2);
        UserInfos.Add(basic3.Username, basic3);

    }


    public bool checkUsernameAndPass(string username, string pass)
    {
        if (LoginInfos.ContainsKey(username))
        {
            return LoginInfos[username].Equals(pass);

        }
        return false;
    }

    public bool checkUsername(string username) {
        return LoginInfos.ContainsKey(username);
    }

    public bool registerUser(string username, string pass, string email)
    {
        if (LoginInfos.ContainsKey(username))
        {
            return false;
        }
        LoginInfos.Add(username, pass);
        UserInfo temp = new UserInfo();
        temp.Email = email;
        temp.Username = username;
        temp.UType = UserInfo.UserType.Visitor;
        UserInfos.Add(username, temp);

        return true;

    }

    public bool LogInUser(string username)
    {

        if (UserInfos.ContainsKey(username))
        {
            curUser = (UserInfo)UserInfos[username];
            return true;
        }
        return false;

    }

    public void LogOutUser()
    {
        curUser = null;
        LogInScreen.SetActive(true);
        LogInScreen.GetComponent<LoginScreen>().TurnOffButtons();
    }

    public UserInfo getCurUser()
    {
        return curUser;
    }

    public List<AnimalInfo> GetAnimalInfos()
    {
        return animalinfos;
    }



    public void AddPendingRequest(PendingOrders po)
    {
        penOrders.Add(po);
    }

    public List<Content> getContent()
    {
        return contentList;
    }

    public void addAnimal(AnimalInfo ai)
    {
        if (ai == null) return;
        animalinfos.Add(ai);
    }

    public List<PendingOrders> getPenOrders()
    {
        return penOrders;
    }

    public void addNotification(string username, NotificationInfo ni)
    {
        if (UserInfos.ContainsKey(username))
        {
            UserInfo ui = (UserInfo)UserInfos[username];
            ui.NotificationInfos.Add(ni);
            ui.UreadNotifications++;
        }
    }

    public void removeOrder(PendingOrders po)
    {
        penOrders.Remove(po);
    }

    //Again bad sec
    public void updatePassword(string username, string password)
    {
        LoginInfos[username] = password;
    }

}
