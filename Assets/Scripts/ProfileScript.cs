using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileScript : MonoBehaviour
{

    [SerializeField] private TMP_InputField Name;
    [SerializeField] private TMP_InputField Surname;
    [SerializeField] private TMP_InputField Address;
    [SerializeField] private TMP_InputField Phone;
    [SerializeField] private TMP_InputField Email;
    [SerializeField] private GameObject GM;
    [SerializeField] private GameObject PasswordScreen;



    [SerializeField] private UserInfo curUser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayInfo(UserInfo ui)
    {
        Name.text = ui.Name;
        Surname.text = ui.Surname;
        Address.text = ui.Address;
        Phone.text = ui.Phone;
        Email.text = ui.Email;
        curUser = ui;

    }

    public void revertInfo()
    {

        Name.text = curUser.Name;
        Surname.text = curUser.Surname;
        Address.text = curUser.Address;
        Phone.text = curUser.Phone;
        Email.text = curUser.Email;

    }


    public void updateUserInfo()
    {
        if (Email.text.Length > 0)
        {
            curUser.Email = Email.text;
        }

        curUser.Name = Name.text;
        curUser.Surname = Surname.text;
        curUser.Address = Address.text;
        curUser.Phone = Phone.text;
        
    }

    public void LogOut()
    {
        GM.GetComponent<MainDB>().LogOutUser();
        GM.GetComponent<NavScript>().NavigateToEmptyPage();
    }

    public void changePassword()
    {
        PasswordScreen.SetActive(true);
        GM.GetComponent<NavScript>().setInteractabilityActiveButtons(false);
    }


}
