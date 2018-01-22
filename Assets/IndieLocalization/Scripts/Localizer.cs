using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndigoBunting.Lang
{
    public class Localizer
    {
        private const string keyPref = "currentLang";
        private const LangCode defaultLang = LangCode.English;

        private Dictionary<string, string> stringsDict = new Dictionary<string, string>();
        private static Localizer instance;

        public LangCode Language { get; private set; }

        public static Localizer Instance
        {
            get { return instance ?? (instance = new Localizer()); }
        }

        public static bool IsNull
        {
            get { return instance == null; }
        }

        private Localizer()
        {
            string currLangString = PlayerPrefs.GetString("keyPref", "default");
            if (currLangString.Equals("default"))
            {
                SetLang(ConvertSystemLanguage(Application.systemLanguage));
            }
            else
            {
                LangCode code = (LangCode) Enum.Parse(typeof(LangCode), currLangString);
                SetLang(code);
            }
        }

        public void SetLang(LangCode code)
        {
            Language = code;
            stringsDict = LanguageXmlReader.Read(code);
            if (OnChangedLanguage != null) OnChangedLanguage(code);
        }

        public string GetText(string key)
        {
            return stringsDict.ContainsKey(key) ? stringsDict[key] : key;
        }

        public static LangCode ConvertSystemLanguage(SystemLanguage selected)
        {
            switch (selected)
            {
                case SystemLanguage.English:
                    return LangCode.English;
                case SystemLanguage.Spanish:
                    return LangCode.Spanish;
                case SystemLanguage.Portuguese:
                    return LangCode.PortuguesePortugal;
                case SystemLanguage.Russian:
                    return LangCode.Russian;
                case SystemLanguage.Turkish:
                    return LangCode.Turkish;
                case SystemLanguage.German:
                    return LangCode.German;
                default:
                    return defaultLang;
            }
        }

        private static Dictionary<LangCode, string> iso639 = new Dictionary<LangCode, string>()
        {
            {LangCode.English, "en"},
            {LangCode.Spanish, "es"},
            {LangCode.PortuguesePortugal, "pt"},
            {LangCode.PortugueseBrazil, "pt-br"},
            {LangCode.Russian, "ru"},
            {LangCode.Turkish, "tr"},
            {LangCode.German, "de"},
            {LangCode.Italian, "it"}
        };

        public event Action<LangCode> OnChangedLanguage;
    }

    public enum LangCode
    {
        English,
        Spanish,
        PortuguesePortugal,
        PortugueseBrazil,
        Russian,
        Turkish,
        German,
        Italian
    }
}