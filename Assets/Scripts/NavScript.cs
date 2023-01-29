using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavScript : MonoBehaviour
{


    [SerializeField] private GameObject Home;
    [SerializeField] private GameObject Events;
    [SerializeField] private GameObject Animals;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject Info;
    [SerializeField] private GameObject Profile;
    [SerializeField] private GameObject SingleAnimalPage;
    [SerializeField] private GameObject EmptyPage;
    [SerializeField] private GameObject AddingAnimal;
    [SerializeField] private GameObject PendingOrdersPage;

    [SerializeField] private GameObject currentPage;
    [SerializeField] private GameObject GM;
    [SerializeField] private GameObject NavBar;

    

    // Start is called before the first frame update
    void Start()
    {
        currentPage = EmptyPage;
    }

    public void NavigateToHome()
    {
        currentPage.SetActive(false);
        Home.SetActive(true);
        Home.GetComponent<MainPageScript>().initContent();
        currentPage = Home;
    }

    public void NavigateToEvents()
    {
        currentPage.SetActive(false);
        Events.SetActive(true);
        currentPage = Events;
    }

    public void NavigateToAnimals()
    {
        currentPage.SetActive(false);
        Animals.SetActive(true);
        currentPage = Animals;
        Animals.GetComponent<AnimalsScript>().InitPage();
    }

    public void NavigateToShop()
    {
        currentPage.SetActive(false);
        Shop.SetActive(true);
        Shop.GetComponent<ShopScript>().checkUser();
        currentPage = Shop;
    }
    public void NavigateToInfo()
    {
        currentPage.SetActive(false);
        Info.SetActive(true);
        Info.GetComponent<InfoScript>().initPage();
        currentPage = Info;
    }
    public void NavigateToProfile()
    {
        currentPage.SetActive(false);
        Profile.SetActive(true);
        Profile.GetComponent<ProfileScript>().displayInfo(GM.GetComponent<MainDB>().getCurUser());
        currentPage = Profile;
    }

    public void NavigateToSingleAnimalPage(AnimalInfo ai)
    {
        currentPage.SetActive(false);
        SingleAnimalPage.SetActive(true);
        SingleAnimalPage.GetComponent<SingleAnimalScript>().initPage(ai);
        currentPage = SingleAnimalPage;
    }

    public void NavigateToEmptyPage()
    {
        currentPage.SetActive(false);
        EmptyPage.SetActive(true);
        //LoginActive
        //Deactivate Buttons
        currentPage = EmptyPage;
    }

    public void NavigateToAddingAnimal()
    {
        currentPage.SetActive(false);
        AddingAnimal.SetActive(true);
        currentPage = AddingAnimal;
    }

    public void NavigateToPenOrders()
    {
        currentPage.SetActive(false);
        PendingOrdersPage.SetActive(true);
        PendingOrdersPage.GetComponent<PenOrdersPage>().initPage();
        currentPage = PendingOrdersPage;
    }

    
    public void setInteractabilityActiveButtons(bool state)
    {
        foreach (Button item in NavBar.GetComponentsInChildren<Button>())
        {
            item.interactable = state;
        }


        if (currentPage) {
            foreach (Button item in currentPage.GetComponentsInChildren<Button>())
            {
                item.interactable = state;
            }
        }

    }

}
