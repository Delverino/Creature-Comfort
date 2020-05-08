using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    //public int destinationScene;
    public Animator anim;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(nextLevel());
        }
    }

    IEnumerator nextLevel()
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(0.99f);
        PlayerPrefs.SetInt("SaveL",SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
