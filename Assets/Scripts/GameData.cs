using UnityEngine;
using TMPro;
using System.IO;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public string playerName;

    public int bestScore;
    public string bestPlayerName;

    [SerializeField] private GameObject inputField;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            return;
        }
        
        LoadBestScore();
        
        bestScoreText.GetComponent<TextMeshProUGUI>().text = "Best Score: " + bestPlayerName + " " + bestScore;
    }

    // Stores the player name from the input field
    public void SetPlayerName()
    {
        playerName = inputField.GetComponent<TMP_InputField>().text;
        //Debug.Log("username = " + playerName);
    }

    // for serializable data to be saved to file
    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestPlayer;
    }

    // Save Score and Player Name to file
    public void SaveBestScore(int score)
    {
        SaveData data = new SaveData();
        data.BestScore = score;
        data.BestPlayer = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        //Debug.Log("Best score saved = " + data.BestPlayer + " " + data.BestScore);
    }

    // Load Best Score from file
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.BestScore;
            bestPlayerName = data.BestPlayer;
        }

        //Debug.Log("Best Score loaded = " + bestPlayerName + " " + bestScore);
    }
}
