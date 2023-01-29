using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class AnimalInfo
{

    [SerializeField] private string name;
    [SerializeField] private string miniDesc;
    [SerializeField] private string fullDesc;
    [SerializeField] private Sprite mySprite;
    [SerializeField] private List<CommentScript> commentList = new List<CommentScript>();

    public List<CommentScript> MyCommentList
    {
        get { return commentList; }
        set { commentList = value; }
    }

    public Sprite MySprite
    {
        get { return mySprite; }
        set { mySprite = value; }
    }

    public string FullDesc
    {
        get { return fullDesc; }
        set { fullDesc = value; }
    }


    public string MiniDesc
    {
        get { return miniDesc; }
        set { miniDesc = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }


}
