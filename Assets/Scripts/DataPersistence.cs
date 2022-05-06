using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DataPersistence : MonoBehaviour
{
    public static DataPersistence dataPersistenceScript;
    public string playerName;
    public InputField playerNameInput;//initialized with drag&drop
    
    
    private void Awake()
    {
       
        dataPersistenceScript = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        
        playerName = playerNameInput.text;
    }

}
