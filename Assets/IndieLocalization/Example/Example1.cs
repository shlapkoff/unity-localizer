using System.Collections;
using System.Collections.Generic;
using IndigoBunting.Lang;
using UnityEngine;

public class Example1 : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeLanguage()
    {
        if (Localizer.Instance.Language == LangCode.Russian)
        {
            Localizer.Instance.SetLang(LangCode.English);
        }
        else
        {
            Localizer.Instance.SetLang(LangCode.Russian);
        }
    }
}