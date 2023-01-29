using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginScreen : MonoBehaviour
{


    [SerializeField]
    GameObject ContentScrollView;

    public RectTransform usernameField;
    public RectTransform passwordField;

    public GameObject SignUpForm;
    public GameObject GM;

    private TMP_InputField username;
    private TMP_InputField password;

    private TMP_Text placeholderUsername;
    private TMP_Text placeholderPassword;

    private MainDB mainDb;

    [SerializeField] private Button Home;
    [SerializeField] private Button Animals;
    [SerializeField] private Button Shop;
    [SerializeField] private Button Profile;
    [SerializeField] private Button Info;
    [SerializeField] private Button PenOrders;
    [SerializeField] private Button AddAnimal;
    [SerializeField] private Button Contact;

    // Start is called before the first frame update
    void Start()
    {

        username = usernameField.GetComponent<TMP_InputField>();
        password = passwordField.GetComponent<TMP_InputField>();

        placeholderUsername = username.GetComponentInChildren<TMP_Text>(); 
        placeholderPassword = password.GetComponentInChildren<TMP_Text>();

        mainDb = GM.GetComponent<MainDB>();
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void login()
    {

        string temp = null;

        if (mainDb.checkUsernameAndPass(username.text, password.text)) { 
            Debug.Log("Successful Login for user " + username);
            if (mainDb.LogInUser(username.text))
            {
                this.gameObject.SetActive(false);

                UserInfo ui = mainDb.getCurUser();
                if (ui.UType == UserInfo.UserType.Visitor)
                {
                    Home.gameObject.SetActive(true);
                    Animals.gameObject.SetActive(true);
                    Shop.gameObject.SetActive(true);
                    Info.gameObject.SetActive(true);
                    Profile.gameObject.SetActive(true);
                    Contact.gameObject.SetActive(true);

                    GM.GetComponent<NavScript>().NavigateToHome();

                }
                else
                {
                    Contact.gameObject.SetActive(true);
                    PenOrders.gameObject.SetActive(true);
                    AddAnimal.gameObject.SetActive(true);
                    Profile.gameObject.SetActive(true);
                    GM.GetComponent<NavScript>().NavigateToAddingAnimal();
                }

                username.text = "";
                password.text = "";
                placeholderUsername.text = "Username";
                placeholderPassword.text = "Password";
            }
            else
            {
                Debug.Log("Unsuccessful login for user " + username + " unknown error");
            }
        }
        else
        {
            Debug.Log("Unsuccessful login for user " + username);
            username.text = "";
            password.text = "";
            placeholderUsername.text = "Credentials not found";
            placeholderPassword.text = "Credentials not found";
        }
    }

    public void registerForm()
    {
        this.gameObject.SetActive(false);
        SignUpForm.SetActive(true);
    }

    public void fromRegister(string s)
    {
        this.gameObject.SetActive(true);
        username.text = "";
        password.text = "";
        placeholderUsername.text = s;
        placeholderPassword.text = s;
    }

    public void TurnOffButtons()
    {
        Home.gameObject.SetActive(false);
        Animals.gameObject.SetActive(false);
        Shop.gameObject.SetActive(false);
        Info.gameObject.SetActive(false);
        Profile.gameObject.SetActive(false);
        Contact.gameObject.SetActive(false);
        PenOrders.gameObject.SetActive(false);
        AddAnimal.gameObject.SetActive(false);
    }
}
