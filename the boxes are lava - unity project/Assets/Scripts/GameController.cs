using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    GameObject player;
    SoundController soundController;

    void Start()
    {
        soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void RestartLevelMethod()
    {
        //themeMusicController.audioSource.volume = themeMusicController.defaultVolume;
        soundController.FindSound("Theme").source.volume = soundController.defaultVolume;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield break;
    }

    IEnumerator NextLevel()
    {
        //soundController.PlaySound("Win");
        
        player.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0.001f);

        yield return new WaitForSeconds(2f);

        //themeMusicController.audioSource.volume = themeMusicController.defaultVolume;

        soundController.FindSound("Theme").source.volume = soundController.defaultVolume;

        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        yield break;
    }
}
