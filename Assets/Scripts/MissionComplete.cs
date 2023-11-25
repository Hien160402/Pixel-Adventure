using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MissionComplete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlaySFX("win");
            SceneController.instance.NextLevel();
        }
    }
}
