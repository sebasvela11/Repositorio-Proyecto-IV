using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text text;
    int Total;
    public Text levelCleared;
    void Start()
    {
        Total = gameObject.transform.childCount;
        FruitCount();
    }

    void Update()
    {
        FruitCount();
    }

    void FruitCount()
    {
        int count = gameObject.transform.childCount;
        text.text = "Frutas recolectadas: " + (Total - count) + " / " + Total;
        if(count == 0)
        {
            levelCleared.gameObject.SetActive(true);
            Invoke("ChangeScene", 2);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
