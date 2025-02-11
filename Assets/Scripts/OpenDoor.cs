using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public Text text;
    public string levelName;
    public string levelText;
    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            text.text = "Presione x para ingresar a " + levelText;
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
            inDoor = false;
        }
    }

    private void Update()
    {
        if(inDoor && Input.GetKey("x"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
