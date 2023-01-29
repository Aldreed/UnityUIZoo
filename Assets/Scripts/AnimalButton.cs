using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalButton : MonoBehaviour
{

    [SerializeField] private AnimalInfo curAnimal;
    
    private GameObject AnimalPage;

    //Bad connection 
    [SerializeField] private GameObject nav;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PD()
    {
        Debug.Log(curAnimal.Name);
        Debug.Log(curAnimal.MiniDesc);

        if (nav != null)
        {
            NavScript navS = nav.GetComponent<NavScript>();
            if (navS)
            {
            navS.NavigateToSingleAnimalPage(curAnimal);
            }
            else
            {
                Debug.Log("Bad Nav");
            }
        }
        else
        {
            Debug.Log("No Nav found");
        }



    }

    public void setCurrentAnimal(AnimalInfo ai)
    {
        curAnimal = ai;
    }

    public void setNav(GameObject o)
    {
        nav = o;
    }
}
