
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public void PlayGame()
    {
        int recordedLevel = PlayerPrefs.GetInt("record");
        if (recordedLevel==0)
        {
            SceneManager.LoadScene("1");
        }
        else
        {
            SceneManager.LoadScene(recordedLevel);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("1");
    }
}
