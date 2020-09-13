using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelMenu : MonoBehaviour {

    bool adPlayed;

    private void Start()
    {
        adPlayed = false;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        if(adPlayed == true)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            //AdManager advertisement = new AdManager();
            //advertisement.DisplayAd();
              adPlayed = true;
        }


    }

    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}
