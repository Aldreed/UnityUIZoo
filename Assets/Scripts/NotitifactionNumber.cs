using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotitifactionNumber : MonoBehaviour
{

    [SerializeField] private TMP_Text notificationNumber;
    [SerializeField] private GameObject notificationBg;
    [SerializeField] private GameObject GM;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UserInfo curUser = GM.GetComponent<MainDB>().getCurUser();
        if(curUser != null)
        {
            int newNotifications = curUser.UreadNotifications;
            if(newNotifications < 10 && newNotifications > 0)
            {
                notificationBg.SetActive(true);
                notificationNumber.gameObject.SetActive(true);
                notificationNumber.text = curUser.UreadNotifications.ToString();
            }
            else if (newNotifications >= 10)
            {
                notificationBg.SetActive(true);
                notificationNumber.gameObject.SetActive(true);
                notificationNumber.text = "9+";
            }
            else
            {
                notificationBg.SetActive(false);
                notificationNumber.gameObject.SetActive(false);
            }
        }
        else
        {
            notificationBg.SetActive(false);
            notificationNumber.gameObject.SetActive(false);
        }
    }
}
