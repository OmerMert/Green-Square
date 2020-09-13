using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelsScript : MonoBehaviour {


    public Button[] LevelB;
    public static bool[] levelPassed = new bool[19];

    public Sprite Unlocked;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        for (int i = 0;i < 9;i++)
        {
            if (levelPassed[i] == true)
            {
                LevelB[i+1].image.sprite = Unlocked;
                LevelB[i+1].interactable = true;
            }
            else
            {
                LevelB[i+1].interactable = false;
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            for (int i = 9; i < 19; i++)
            {
                if (levelPassed[i] == true)
                {
                    LevelB[i + 1].image.sprite = Unlocked;
                    LevelB[i + 1].interactable = true;
                }
                else
                {
                    LevelB[i + 1].interactable = false;
                }
            }

        }
        

    }

    public void NextPage()
    {
        SceneManager.LoadScene("Levels2");
    }
    public void PreviousPage()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");

    }

    public void Level1()
    {
        SceneManager.LoadScene("LevelI");
    }
    public void Level2()
    {
        SceneManager.LoadScene("LevelII");
    }
    public void Level3()
    {
        SceneManager.LoadScene("LevelIII");
    }
    public void Level4()
    {
        SceneManager.LoadScene("LevelIV");
    }
    public void Level5()
    {
        SceneManager.LoadScene("LevelV");
    }
    public void Level6()
    {
        SceneManager.LoadScene("LevelVI");
    }
    public void Level7()
    {
        SceneManager.LoadScene("LevelVII");
    }
    public void Level8()
    {
        SceneManager.LoadScene("LevelVIII");
    }
    public void Level9()
    {
        SceneManager.LoadScene("LevelIX");
    }
    public void Level10()
    {
        SceneManager.LoadScene("LevelX");
    }
    public void Level11()
    {
        SceneManager.LoadScene("LevelXI");
    }
    public void Level12()
    {
        SceneManager.LoadScene("LevelXII");
    }
    public void Level13()
    {
        SceneManager.LoadScene("LevelXIII");
    }
    public void Level14()
    {
        SceneManager.LoadScene("LevelXIV");
    }
    public void Level15()
    {
        SceneManager.LoadScene("LevelXV");
    }
    public void Level16()
    {
        SceneManager.LoadScene("LevelXVI");
    }
    public void Level17()
    {
        SceneManager.LoadScene("LevelXVII");
    }
    public void Level18()
    {
        SceneManager.LoadScene("LevelXVIII");
    }

    public void Level19()
    {
        SceneManager.LoadScene("LevelXIX");
    }
    public void Level20()
    {
        SceneManager.LoadScene("LevelXX");
    }



}
