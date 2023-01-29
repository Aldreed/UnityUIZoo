using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalsScript : MonoBehaviour
{

    [SerializeField] private GameObject GM;
    [SerializeField] private GameObject AnimalPrefab;
    [SerializeField] private GameObject Content;
    [SerializeField] private List<AnimalInfo> ainfos;
    [SerializeField] private int curInt;
    [SerializeField] private TMP_Text num;
    [SerializeField] private int mulInt = 5;

    


    private void Awake()
    {
        ainfos = GM.GetComponent<MainDB>().GetAnimalInfos();
    }

    public void InitPage()
    {
        int counter = 0;
        clearAnimals();
        foreach (var item in ainfos)
        {
            GameObject temp = Instantiate(AnimalPrefab, Content.transform);
            Image[] images = temp.GetComponentsInChildren<Image>();
            images[1].sprite = item.MySprite;
            TMP_Text[] texts = temp.GetComponentsInChildren<TMP_Text>();
            texts[0].text = item.Name;
            texts[1].text = item.MiniDesc;
            temp.GetComponentInChildren<AnimalButton>().setCurrentAnimal(item);

            //Bad connection
            temp.GetComponentInChildren<AnimalButton>().setNav(GM);

            if (++counter == mulInt)
            {
                break;
            }
        }
        curInt = 1;
        num.text = curInt.ToString();
    }

    public void NextPage()
    {
        if (curInt * mulInt >= ainfos.Count)
        {
            return;
        }
        clearAnimals();
        for (int i = curInt*mulInt; i < ainfos.Count;)
        {
            var item = ainfos[i];
            GameObject temp = Instantiate(AnimalPrefab, Content.transform);
            Image[] images = temp.GetComponentsInChildren<Image>();
            images[1].sprite = item.MySprite;
            TMP_Text[] texts = temp.GetComponentsInChildren<TMP_Text>();
            texts[0].text = item.Name;
            texts[1].text = item.MiniDesc;
            temp.GetComponentInChildren<AnimalButton>().setCurrentAnimal(item);

            //Bad connection
            temp.GetComponentInChildren<AnimalButton>().setNav(GM);

            if (++i== (curInt + 1) * mulInt)
            {
                break;
            }
        }

        curInt++;
        num.text = curInt.ToString();
    }

    public void PrevPage()
    {
        if (curInt <= 1)
        {
            return;
        }
        clearAnimals();
        for (int i = (curInt - 2) * mulInt; i < ainfos.Count;)
        {
            var item = ainfos[i];
            GameObject temp = Instantiate(AnimalPrefab, Content.transform);
            Image[] images = temp.GetComponentsInChildren<Image>();
            images[1].sprite = item.MySprite;
            TMP_Text[] texts = temp.GetComponentsInChildren<TMP_Text>();
            texts[0].text = item.Name;
            texts[1].text = item.MiniDesc;
            temp.GetComponentInChildren<AnimalButton>().setCurrentAnimal(item);

            //Bad connection
            temp.GetComponentInChildren<AnimalButton>().setNav(GM);

            if (++i == (curInt-1) * mulInt)
            {
                break;
            }
        }

        curInt--;
        num.text = curInt.ToString();
    }




    private void clearAnimals()
    {
        Transform[] children = Content.GetComponentsInChildren<Transform>();

        foreach (Transform item in children)
        {
            if (item.tag == "Animal")
            {
                Destroy(item.gameObject);
            }
        }
    }

}
