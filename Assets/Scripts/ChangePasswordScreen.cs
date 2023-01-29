using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangePasswordScreen : MonoBehaviour
{
    [SerializeField] TMP_InputField password; 
    [SerializeField] TMP_InputField newPassword; 
    [SerializeField] TMP_InputField confirmPassword;
    [SerializeField] TMP_Text notification;
    [SerializeField] GameObject GM;


    public void changePassword()
    {

        string username = GM.GetComponent<MainDB>().getCurUser().Username;
        if (password.text.Length <= 0)
        {
            notification.text = "Please enter your password";
            return;
        }
        else if (newPassword.text.Length <= 0) {
            notification.text = "Please enter your new password";
            return;
        }
        else if (confirmPassword.text.Length <= 0)
        {
            notification.text = "Please confirm your password";
            return;
        }
        else if (!confirmPassword.text.Equals(newPassword.text))
        {
            notification.text = "Confirmation dosn't match";
            return;
        }
        else if (!GM.GetComponent<MainDB>().checkUsernameAndPass(username,password.text))
        {
            notification.text = "Wrong password";
            return;
        }
        else
        {
            GM.GetComponent<MainDB>().updatePassword(username, newPassword.text);
            newPassword.text = "";
            confirmPassword.text = "";
            password.text = "";
            notification.text = "Password Changed";
            
        }
    }

    public void closeScreen()
    {
        this.gameObject.SetActive(false);
        GM.GetComponent<NavScript>().setInteractabilityActiveButtons(true);
    }
}
