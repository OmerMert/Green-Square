
[System.Serializable]
public class PlayerData {

    public int coin;
    public int colour;
    public int[] colourBuyed;
    public int[] level;
    public float sound;

    public PlayerData()
    {
        coin = PointTextScript.coinAmount;
        colour = CustomizationScript.Colour;

        colourBuyed = new int[5];
        colourBuyed[0] = BoolToInt(CustomizationScript.OrangeBuyed);
        colourBuyed[1] = BoolToInt(CustomizationScript.RedBuyed);
        colourBuyed[2] = BoolToInt(CustomizationScript.WhiteBuyed);
        colourBuyed[3] = BoolToInt(CustomizationScript.YellowBuyed);
        colourBuyed[4] = BoolToInt(CustomizationScript.PinkBuyed);


        level = new int[19];

        for (int i = 0; i < 19; i++)
        {
            level[i] = BoolToInt(LevelsScript.levelPassed[i]);
        }

        
    }

    int BoolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }
}
