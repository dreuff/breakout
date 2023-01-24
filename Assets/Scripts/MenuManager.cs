using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public TMP_InputField nameField;
    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartNew);
        
    }

    void StartNew()
    {
        GameManager.Instance.currentPlayer = nameField.text;
        SceneManager.LoadScene(1);
    }
}
