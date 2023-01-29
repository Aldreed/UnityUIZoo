using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotificationPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text notification;
    [SerializeField] private GameObject GM;



    public void showPopUp(string s)
    {
        notification.text = s;
        GM.GetComponent<NavScript>().NavigateToHome();
        GM.GetComponent<NavScript>().setInteractabilityActiveButtons(false);


    }

    public void endPopUp()
    {
        this.gameObject.SetActive(false);
        GM.GetComponent<NavScript>().setInteractabilityActiveButtons(true);
    }

}
