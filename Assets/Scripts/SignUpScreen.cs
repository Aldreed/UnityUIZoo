using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignUpScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public RectTransform EmailField;
    public RectTransform UsernameField;
    public RectTransform PasswordField;
    public RectTransform ConfirmPasswordField;

    public GameObject GM;
    public GameObject LoginForm;

    private TMP_InputField Email;
    private TMP_InputField Username;
    private TMP_InputField Password;
    private TMP_InputField ConfirmPassword;

    private TMP_Text placeholderEmail;
    private TMP_Text placeholderUsername;
    private TMP_Text placeholderPassword;
    private TMP_Text placeholderConfirmPassword;

    private MainDB mainDB;
    
    void Start()
    {
        Email = EmailField.GetComponent<TMP_InputField>();
        Username = UsernameField.GetComponent<TMP_InputField>();
        Password = PasswordField.GetComponent<TMP_InputField>();
        ConfirmPassword = ConfirmPasswordField.GetComponent<TMP_InputField>();

        placeholderEmail = Email.GetComponentInChildren<TMP_Text>();
        placeholderUsername = Username.GetComponentInChildren<TMP_Text>();
        placeholderPassword = Password.GetComponentInChildren<TMP_Text>();
        placeholderConfirmPassword = ConfirmPassword.GetComponentInChildren<TMP_Text>();

        mainDB = GM.GetComponent<MainDB>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void register()
    {
        if(Email.text.Length == 0)
        {
            placeholderEmail.text = "Field Required";
            //No check to see if the email is already used by another user
        }
        else if (Username.text.Length == 0)
        {
            placeholderUsername.text = "Field Required";
        }
        else if (mainDB.checkUsername(Username.text)) {
            placeholderUsername.text = "Username taken";
        }
        else if (Password.text.Length == 0)
        {
            placeholderPassword.text = "Field Required";
        }
        else if (!Password.text.Equals(ConfirmPassword.text))
        {
            ConfirmPassword.text = "";
            placeholderConfirmPassword.text = "Must Match Password";
        }
        else
        {
            if (mainDB.registerUser(Username.text, Password.text, Email.text))
            {
                Username.text = "";
                Email.text = "";
                Password.text = "";
                ConfirmPassword.text = "";

                Tologin("Registration Successful");
            }
            else
            {
                placeholderUsername.text = "Unknown Error";
                placeholderEmail.text = "Unknown Error";
                placeholderPassword.text = "Unknown Error";
                placeholderConfirmPassword.text = "Unknown Error";
            }


        }

    }

    public void Tologin(string msg)
    {
        LoginForm.GetComponent<LoginScreen>().fromRegister(msg);
        this.gameObject.SetActive(false);
    }
}
