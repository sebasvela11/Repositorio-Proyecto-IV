using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text text;
    int Total;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
