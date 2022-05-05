using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;//lines of bricks number
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

 


    // Start is called before the first frame update
    void Start()
    {
        
        
        
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);//pooooiiiinnnnttttsss are added here
            }
        }
    }

    private void Update()
    {
        
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = UnityEngine.Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }//space ball release
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
              
            }
        }//space game replay

    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }//Score

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
      
    }


    //save Class
    [Serializable]
    public class ScoreData
    {
        public int scoreNumber;
    }

   
    public void SaveScore()
    {
        ScoreData data = new ScoreData();//object created
        data.scoreNumber = m_Points;//variables initialized
        string scoreData = JsonUtility.ToJson(data);//object converted to string
        File.WriteAllText(Application.persistentDataPath + "/ScoreDataFile.json", scoreData);
        //string to file
        print("Saved");


    }

    public void LoadScore()
    {
        string scoreData = File.ReadAllText(Application.persistentDataPath + "/ScoreDataFile.json");
        //file to text
        ScoreData data = JsonUtility.FromJson<ScoreData>(scoreData);
        //text to object
        m_Points = data.scoreNumber;//setting values
        print("Loaded");
    }



}
