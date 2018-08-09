using System.Collections;
using System.Collections.Generic;
using IndigoBunting.Lang;
using UnityEngine;

public class Example1 : MonoBehaviour
{
    public void ChangeLanguage()
    {
        if (Localizer.Language == Language.Russian)
        {
            Localizer.SetLang(Language.English);
        }
        else
        {
            Localizer.SetLang(Language.Russian);
        }
    }
}