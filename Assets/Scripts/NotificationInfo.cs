using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationInfo
{
    private string text;
    private string date;
    private bool read = false;

    public bool Read
    {
        get { return read; }
        set { read = value; }
    }

    public string Date
    {
        get { return date; }
        set { date = value; }
    }

    public string NotificationText
    {
        get { return text; }
        set { text = value; }
    }

}
