using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string currentPlayer;
    public string bestPlayer = "";
    public int bestScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Save()
    {
        BestScore best = new BestScore();
        best.name = this.bestPlayer;
        best.score = this.bestScore;
        string json = JsonUtility.ToJson(best);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore data = JsonUtility.FromJson<BestScore>(json);

            this.bestPlayer = data.name;
            this.bestScore = data.score;
        }
    }
   
}

[System.Serializable]
class BestScore
{
    public string name;
    public int score;
}
