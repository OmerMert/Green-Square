using UnityEngine;

public class SaveSystem2 : MonoBehaviour {

    private void Start()
    {
        Load();
    }
    private void Update()
    {
        Invoke("Save", 1);
    }


    public void Save()
    {
        SaveSystem.SaveStatus();
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        PointTextScript.coinAmount = data.coin;

        CustomizationScript.Colour = data.colour;

        CustomizationScript.OrangeBuyed = IntToBool(data.colourBuyed[0]);
        CustomizationScript.RedBuyed = IntToBool(data.colourBuyed[1]);
        CustomizationScript.WhiteBuyed = IntToBool(data.colourBuyed[2]);
        CustomizationScript.YellowBuyed = IntToBool(data.colourBuyed[3]);
        CustomizationScript.PinkBuyed = IntToBool(data.colourBuyed[4]);

        for (int i = 0; i < 19; i++)
        {
            LevelsScript.levelPassed[i] = IntToBool(data.level[i]);
        }

        
    }
    

    bool IntToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
