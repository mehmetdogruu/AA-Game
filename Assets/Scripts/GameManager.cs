using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject rotatingCircle;
    GameObject mainCircle;
    public Animator animator;
    public TMP_Text level;
    public TMP_Text kunaiCount;
    public int kunaiCountonStart;
    void Start()
    {
        PlayerPrefs.SetInt("record", int.Parse(SceneManager.GetActiveScene().name));
        PlayerPrefs.GetInt("record");
        rotatingCircle = GameObject.FindGameObjectWithTag("Circle");
        mainCircle = GameObject.FindGameObjectWithTag("Ninja");
        level.text = SceneManager.GetActiveScene().name;
        kunaiCount.text = kunaiCountonStart + "";
    }
    IEnumerator SecondCalledMethod()
    {
        rotatingCircle.GetComponent<CircleRotation>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        animator.SetTrigger("NextLevel");
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene().name=="3")
        {
            SceneManager.LoadScene(0);
        }
        else 
        {
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
    }
    void NextLevel()
    {
        StartCoroutine(SecondCalledMethod());
    }
    public void KunaiCount()
    {
        if (kunaiCountonStart!=0)
        {
            kunaiCount.text = kunaiCountonStart + "";
            kunaiCountonStart--;
        }
        else
        {
            kunaiCount.text = "0";
            NextLevel();
        }
    }
    public void GameOver()
    {
        StartCoroutine(CalledMethod());
    }
     IEnumerator CalledMethod()
    {
        rotatingCircle.GetComponent<CircleRotation>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        animator.SetTrigger("GameOver");
        

        yield return new WaitForSeconds(1);
        if (PlayerPrefs.GetInt("record")!= 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("record"));
        }
    }

    
}
