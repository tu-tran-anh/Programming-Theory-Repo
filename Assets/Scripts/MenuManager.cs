using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public int currentScore = 0;
    public string playerName;
    public bool gameOver = false;

    public int mode = 1;
    public int bestScore;
    public string bestName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestPlay();
    }
    public class SaveData{
        public int bestScore;
        public string bestName;
    }

    public void SaveBestPlay()
    {
        SaveData data = new SaveData();
        data.bestScore = MenuManager.Instance.bestScore;
        data.bestName = MenuManager.Instance.bestName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestPlay()
    {
        SaveData data = new SaveData();
        string json = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        data = JsonUtility.FromJson<SaveData>(json);
        bestScore = data.bestScore;
        bestName = data.bestName;
    }
}
