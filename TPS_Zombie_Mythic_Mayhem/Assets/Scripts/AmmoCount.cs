using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoCount : MonoBehaviour
{
    public TextMeshProUGUI ammunitionText;
    public TextMeshProUGUI magText;

    public static AmmoCount occurance;


    private void Awake()
    {
        occurance = this;
    }


    public void UpdateAmmoText(int presentAmmunition)
    {
        ammunitionText.text = "" + presentAmmunition;

    }


    public void UpdateMagText(int presentMag)
    {
        magText.text = "" + presentMag;
    }

}
