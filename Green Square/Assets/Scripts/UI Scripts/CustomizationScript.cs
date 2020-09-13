using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomizationScript : MonoBehaviour {

    public TextMeshProUGUI TotalPointText;

    public Text orangetext, redtext, whitetext, yellowtext, pinktext;

    public static bool OrangeBuyed, RedBuyed, WhiteBuyed, YellowBuyed, PinkBuyed;

    public static int Colour;

    public Image Character;

    public Sprite[] Colours;

    void Update()
    {
        TotalPointText.text =PointTextScript.coinAmount.ToString();

        for(int i = 1;i <= 6;i++)
        {
            if (Colour == i)
                Character.sprite = Colours[i - 1];
        }



        if (OrangeBuyed == true)
            orangetext.text = "Choose";
        if (RedBuyed == true)
            redtext.text = "Choose";
        if (WhiteBuyed == true)
            whitetext.text = "Choose";
        if (YellowBuyed == true)
            yellowtext.text = "Choose";
        if (PinkBuyed == true)
            pinktext.text = "Choose";


    }


    // CHANGING PLAYER'S COLOUR
    public void ColourGreen()
    {
        Colour = 1;
    }

    public void ColourOrange()
    {
        if (OrangeBuyed == false)
        {
            if (PointTextScript.coinAmount >= 10)
            {
                PointTextScript.coinAmount -= 10;
                OrangeBuyed = true;
                Colour = 2;
            }
        }
        else
        {
            Colour = 2;
        }   
    }

    public void ColourRed()
    {
        if (RedBuyed == false)
        {
            if (PointTextScript.coinAmount >= 15)
            {
                PointTextScript.coinAmount -= 15;
                RedBuyed = true;
                Colour = 3;
            }
        }
        else
        {
            Colour = 3;
        }
    }

    public void ColourBlue()
    {
        if (WhiteBuyed == false)
        {
            if (PointTextScript.coinAmount >= 20)
            {
                PointTextScript.coinAmount -= 20;
                WhiteBuyed = true;
                Colour = 4;
            }
        }
        else
        {
            Colour = 4;
        }
    }

    public void ColourYellow()
    {
        if (YellowBuyed == false)
        {
            if (PointTextScript.coinAmount >= 25)
            {
                PointTextScript.coinAmount -= 25;
                YellowBuyed = true;
                Colour = 5;
            }
        }
        else
        {
            Colour = 5;
        }
    }

    public void ColourPink()
    {
        if (PinkBuyed == false)
        {
            if (PointTextScript.coinAmount >= 30)
            {
                PointTextScript.coinAmount -= 30;
                PinkBuyed = true;
                Colour = 6;
            }
        }
        else
        {
            Colour = 6;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
