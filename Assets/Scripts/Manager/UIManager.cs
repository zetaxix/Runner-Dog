using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UIManager : MonoBehaviour
{
    [Header("References")]

    [SerializeField] TMP_InputField catNameInput;
    [SerializeField] TMP_Text catNameText;

    [SerializeField] TextMeshPro catText;

    private void Awake()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 1)
        {
            catText = GameObject.Find("CatText").GetComponent<TextMeshPro>();
            catText.text = DataManager.Instance.catName;
        }
    }

    public void StartButton()
    {
        if (catNameInput.text != "")
        {
            DataManager.Instance.catName = catNameInput.text;
            DataManager.Instance.SaveData();
            catNameInput.text = "";

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            Debug.LogError("CatNameText can not be null!");
        }
        
    }

    public void ExitButton()
    {  
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif 

    }

}
