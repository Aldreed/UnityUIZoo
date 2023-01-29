using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ContentDisplay : MonoBehaviour
{

    [SerializeField] public Content myContent;
    [SerializeField] public TMP_Text LikeNumberText;
    [SerializeField] public Button likeButton;
    [SerializeField] public MainDB DB;

    public void likeContent()
    {
        if (myContent != null && LikeNumberText != null)
        {
            myContent.Likes++;
            LikeNumberText.text = myContent.Likes.ToString();
            likeButton.interactable = false;
        }

        UserInfo u = DB.getCurUser();
        myContent.UserLikesLog.Add(u.Username);
       
    }

}
