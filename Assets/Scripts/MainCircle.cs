
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    public GameObject littleCircle;
    GameObject gameManager;
  
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CreateLittleCircle();
        }
    }
    void CreateLittleCircle()
    {
        Instantiate(littleCircle, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().KunaiCount();
    }
}
