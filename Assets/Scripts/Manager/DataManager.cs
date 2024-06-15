using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string catName;

    public TextMeshPro catText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        Data data = new Data();
        data.Name = catName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveCatName.json", json);
    }

    public void LoadData()
    {
        string catNamePath = Application.persistentDataPath + "/saveCatName.json";
        if (File.Exists(catNamePath))
        {
            Data getJson = JsonUtility.FromJson<Data>(File.ReadAllText(catNamePath));

            catName = getJson.Name;
        }

    }


}

public class Data
{
    public string Name;
}
