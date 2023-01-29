using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoScript : MonoBehaviour
{
    [SerializeField] private GameObject GM;
    [SerializeField] private UserInfo curUser;
    [SerializeField] private GameObject NotificationPrefab;
    [SerializeField] private Transform Content;


    public void initPage()
    {
        curUser = GM.GetComponent<MainDB>().getCurUser();
        if(curUser == null)
        {
            return;
        }

        clearNotifications();
        List<NotificationInfo> tempList = curUser.NotificationInfos;

        foreach (NotificationInfo item in tempList)
        {
            GameObject n = Instantiate(NotificationPrefab, Content);
            TMP_Text[] tempText = n.GetComponentsInChildren<TMP_Text>();
            tempText[0].text = item.Date;
            tempText[1].text = item.NotificationText;
            item.Read = true;
            curUser.UreadNotifications--;
        }

    }


    private void clearNotifications()
    {
        Transform[] children = Content.GetComponentsInChildren<Transform>();

        foreach (Transform item in children)
        {
            if (item.tag == "Notification")
            {
                Destroy(item.gameObject);
            }
        }
    }


}
