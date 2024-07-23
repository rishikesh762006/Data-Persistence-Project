using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public static InstanceManager Instance;
    public int bestScore;
    public string playerName;
    public string currentPlayerName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    public class Player
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveData()
    {
        Player player = new Player();
        player.bestScore = bestScore;
        player.playerName = playerName;

        string json = JsonUtility.ToJson(player);
        File.WriteAllText(Application.persistentDataPath + "/player.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Player player = JsonUtility.FromJson<Player>(json);

            bestScore = player.bestScore;
            playerName = player.playerName;
        }
    }
}
