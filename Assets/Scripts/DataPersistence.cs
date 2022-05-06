using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DataPersistence : MonoBehaviour
{
    public static DataPersistence dataPersistenceScript;
    public string playerName;
    public string highScorePlayerName;
    public InputField playerNameInput;//initialized with drag&drop
    public int playerScore;
    public int highScore ;
    [SerializeField] Text HighscoreBoardText;//initialized with drag&drop



    private void Awake()
    {
       if(File.Exists(Application.persistentDataPath + "/ScoreDataFile.json")) { LoadScore(); }
        dataPersistenceScript = this;
        DontDestroyOnLoad(gameObject);
        HighscoreBoardText.text = $"HighScore {highScorePlayerName} --->{highScore}";
    }
   

    private void Update()
    {
        if (playerNameInput != null)
        {
            playerName = playerNameInput.text;
        }//to intrupt the connection
                                       //between inputfiled and variable in new scene
        
        
    }
    public class ScoreData
    {

        public int scoreNumber;
        public string highScorePlayerName;
    }
    public void LoadScore()
    {
        string scoreData = File.ReadAllText(Application.persistentDataPath + "/ScoreDataFile.json");
        //file to text
        ScoreData data = JsonUtility.FromJson<ScoreData>(scoreData);
        //text to object

        highScore = data.scoreNumber;//setting values
        highScorePlayerName = data.highScorePlayerName;
        print("Loaded");

       
    }

}
