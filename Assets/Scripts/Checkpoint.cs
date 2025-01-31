using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerSpawn>().ReachedCheckPoint(
                collision.transform.position.x, 
                collision.transform.position.y, 
                SceneManager.GetActiveScene().buildIndex);

            GetComponent<Animator>().enabled = true;
        }
    }
}
