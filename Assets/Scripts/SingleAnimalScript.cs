using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleAnimalScript : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private AnimalInfo curInfo;
    [SerializeField] private GameObject commentPrefab;
    [SerializeField] private GameObject GM;
    [SerializeField] private TMP_InputField commentField;
    [SerializeField] private TMP_Text animalName;
    [SerializeField] private Image animalImage;
    [SerializeField] private TMP_Text animalDesc;

    public void initPage(AnimalInfo ai)
    {
        curInfo = ai;

        animalName.text = curInfo.Name;
        animalDesc.text = curInfo.FullDesc;
        animalImage.sprite = curInfo.MySprite;
        clearComments();
        foreach (CommentScript item in curInfo.MyCommentList)
        {
            GameObject temp = Instantiate(commentPrefab, content);
            TMP_Text[] texts = temp.GetComponentsInChildren<TMP_Text>();
            texts[0].text = item.MyCommentator;
            texts[1].text = item.Text;
            texts[2].text = item.Date;

        }

    }

    public void AddComment()
    {
        
        if (commentField.text.Length > 0)
        {
            UserInfo ui = GM.GetComponent<MainDB>().getCurUser();
            CommentScript n = new CommentScript();
            n.MyCommentator = ui.Username;
            n.Text = commentField.text;
            n.Date = System.DateTime.Now.ToString("d-M-yyyy");
            curInfo.MyCommentList.Add(n);
            commentField.text = "";
            GameObject temp = Instantiate(commentPrefab, content);
            TMP_Text[] texts = temp.GetComponentsInChildren<TMP_Text>();
            texts[0].text = n.MyCommentator;
            texts[1].text = n.Text;
            texts[2].text = n.Date;
        }
        
        

    }
    private void clearComments()
    {
        Transform[] children = content.GetComponentsInChildren<Transform>();

        foreach (Transform item in children)
        {
            if (item.tag == "Comment")
            {
                Destroy(item.gameObject);
            }
        }
    }
}
