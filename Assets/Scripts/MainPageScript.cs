using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainPageScript : MonoBehaviour
{
    [SerializeField] private GameObject GM;
    [SerializeField] private GameObject contentPrefab;
    [SerializeField] private GameObject contentHolder;

    public void initContent()
    {
        List<Content> contentList = GM.GetComponent<MainDB>().getContent();
        UserInfo curUser = GM.GetComponent<MainDB>().getCurUser();
        clearEvents();
        foreach (Content item in contentList)
        {
            GameObject temp = Instantiate(contentPrefab, contentHolder.transform);
            Image[] images = temp.GetComponentsInChildren<Image>();
            TMP_Text[] texts = temp.GetComponentsInChildren<TMP_Text>();
            images[1].sprite = item.MainImage;
            texts[0].text = item.HeaderText;
            texts[1].text = item.DescText;
            texts[2].text = item.Likes.ToString();

            ContentDisplay cdis = temp.GetComponentInChildren<ContentDisplay>();
            cdis.myContent = item;
            cdis.LikeNumberText = texts[2];
            cdis.DB = GM.GetComponent<MainDB>();

            foreach (string likedUser in item.UserLikesLog)
            {
                if (likedUser.Equals(curUser.Username)){
                    temp.GetComponentInChildren<Button>().interactable = false;
                    break;
                }
            }

            
        }
    }

    private void clearEvents()
    {
        Transform[] children = contentHolder.GetComponentsInChildren<Transform>();

        foreach (Transform item in children)
        {
            if (item.tag == "Event")
            {
                Destroy(item.gameObject);
            }
        }
    }


}
