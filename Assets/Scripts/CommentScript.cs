using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CommentScript
{
    [SerializeField] private string Commetator;
    [SerializeField] private string text;
    [SerializeField] private string date;

    public string Date
    {
        get { return date; }
        set { date = value; }
    }


    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    public string MyCommentator
    {
        get { return Commetator; }
        set { Commetator = value; }
    }

}
