using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Button volume;
    public Sprite VolumeOn, VolumeOff;
    public GameObject RestartUI;
    public void PlayGame()
    {
        SceneManager.LoadScene("Levels");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CharacterCustom()
    {
        SceneManager.LoadScene("Customization");
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

    public void Restart()
    {
        RestartUI.SetActive(true);

    }
    public void No()
    {
        RestartUI.SetActive(false);
    }
    public void Yes()
    {
        RestartUI.SetActive(false);
        for(int i = 0; i<9;i++)
        {
            LevelsScript.levelPassed[i] = false;
        }
        CustomizationScript.OrangeBuyed = false;
        CustomizationScript.RedBuyed = false;
        CustomizationScript.WhiteBuyed = false;
        CustomizationScript.YellowBuyed = false;
        CustomizationScript.PinkBuyed = false;
    }

}
