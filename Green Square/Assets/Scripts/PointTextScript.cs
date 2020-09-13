using TMPro;
using UnityEngine;

public class PointTextScript : MonoBehaviour {

    TextMeshProUGUI PointTxt;
    public static int coinAmount;

    TextMeshProUGUI ChestTxt;

	void Start ()
    {
        PointTxt = GetComponent<TextMeshProUGUI>();
        if (GameObject.Find("Chest"))
        {
            ChestTxt = GameObject.Find("ChestTxt").GetComponent<TextMeshProUGUI>();
            ChestTxt.text = "0";
        }

    }

    void Update ()
    {
        PointTxt.text = coinAmount.ToString();

        if(Chest.isTaken == true && GameObject.Find("Chest"))
        {
            ChestTxt.text = "1";
        }

    }


}
