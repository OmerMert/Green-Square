using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

    public static bool GameIsPause = false;
    public Button volume;
    public Sprite VolumeOn, VolumeOff;
    public GameObject PauseMenuUI;


    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Volume()
    {
        if (volume.image.sprite == VolumeOn)
        {
            volume.image.sprite = VolumeOff;
            AudioListener.volume = 0;

        }
        else
        {
            volume.image.sprite = VolumeOn;
            AudioListener.volume = 1;
        }
    }

    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
