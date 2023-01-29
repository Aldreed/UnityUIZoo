using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class AddingAnimal : MonoBehaviour
{


    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField miniDescInput;
    [SerializeField] private TMP_InputField DescInput;
    [SerializeField] private TMP_Text notificationText;
    [SerializeField] private GameObject GM;
    [SerializeField] private Image currentImage;
    [SerializeField] private GameObject SelectImagePage;
    [SerializeField] private Toggle togglePic1;
    [SerializeField] private Toggle togglePic2;
    [SerializeField] private Toggle togglePic3;
    [SerializeField] private Image AnimalImage1;
    [SerializeField] private Image AnimalImage2;
    [SerializeField] private Image AnimalImage3;

    [SerializeField] private GameObject NavBar;

    private void SetNotificationText(string s)
    {
        notificationText.text = s;
    }

    public void setCurentImageSprite()
    {

        Image temp;

        if (togglePic1.isOn)
        {
            temp = AnimalImage1;
        }
        else if (togglePic2.isOn)
        {
            temp = AnimalImage2;
        }
        else if (togglePic3.isOn)
        {
            temp = AnimalImage3;
        }
        else
        {
            temp = currentImage;
        }

        currentImage.sprite =temp.sprite;
        SelectImagePage.SetActive(false);
        SetNotificationText("Image selected");

        GM.GetComponent<NavScript>().setInteractabilityActiveButtons(true);
    }

    public void chooseAnimal()
    {
        SelectImagePage.SetActive(true);
        GM.GetComponent<NavScript>().setInteractabilityActiveButtons(false);
        
    }

    public void AddAnimal()
    {
        if(nameInput.text.Length <= 0)
        {
            SetNotificationText("Please enter a name");
            return;
        }
        else if (miniDescInput.text.Length <= 0)
        {
            SetNotificationText("Please enter the short description");
            return;
        }
        else if (DescInput.text.Length <= 0)
        {
            SetNotificationText("Please enter the description");
            return;
        }

        MainDB mdb = GM.GetComponent<MainDB>();

        AnimalInfo ai = new AnimalInfo();
        ai.Name = nameInput.text;
        ai.MiniDesc = miniDescInput.text;
        ai.FullDesc = DescInput.text;
        ai.MySprite = currentImage.sprite;

        nameInput.text = "";
        miniDescInput.text = "";
        DescInput.text = "";
        SetNotificationText("Added animal");

        mdb.addAnimal(ai);

    }

    public void turnOff(GameObject o)
    {

        if (o.name == "TogglePic1")
        {
            togglePic2.isOn = false;
            togglePic3.isOn = false;           
        }
        else if (o.name == "TogglePic2")
        {
            togglePic1.isOn = false;
            togglePic3.isOn = false;
        }
        else if (o.name == "TogglePic3")
        {
            togglePic1.isOn = false;
            togglePic2.isOn = false;
        }
    }
}
