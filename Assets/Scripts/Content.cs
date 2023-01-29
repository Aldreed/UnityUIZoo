using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Content
{

    [SerializeField] private string headerText;
    [SerializeField] private string descText;
    [SerializeField] private Sprite mainImage;
    [SerializeField] private int likes;
    [SerializeField] private List<string> userLikesLog;

    public List<string> UserLikesLog
    {
        get { return userLikesLog; }
        set { userLikesLog = value; }
    }


    public int Likes
    {
        get { return  likes; }
        set {  likes = value; }
    }

    public Sprite MainImage
    {
        get { return mainImage; }
        set { mainImage = value; }
    }

    public string DescText
    {
        get { return descText; }
        set { descText = value; }
    }

    public string HeaderText
    {
        get { return headerText; }
        set { headerText = value; }
    }

}
