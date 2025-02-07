using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        if (PlayerPrefs.GetInt("checkPointScene") == SceneManager.GetActiveScene().buildIndex)
        {
            if (PlayerPrefs.GetFloat("checkPointX") != 0 && PlayerPrefs.GetFloat("checkPointY") != 0)
            {
                transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointX"),
                    PlayerPrefs.GetFloat("checkPointY"));
            }
        }
    }

    public void ReachedCheckPoint(float x, float y, int scene)
    {
        PlayerPrefs.SetFloat("checkPointX", x);
        PlayerPrefs.SetFloat("checkPointY", y);
        PlayerPrefs.SetFloat("checkPointScene", scene);
    }

    public void PlayerDamage()
    {
        animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
