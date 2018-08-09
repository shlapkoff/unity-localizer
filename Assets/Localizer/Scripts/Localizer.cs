using System;
using System.Collections.Generic;
using UnityEngine;

namespace IndigoBunting.Lang
{
    public static class Localizer
    {
        private const string rootPath = "Lang/";
        private const string keyPref = "currentLang";
        private const Language defaultLang = Language.English;

        private static Dictionary<string, string> stringsDict = new Dictionary<string, string>();
        public static Language Language { get; private set; }
        
        static Localizer()
        {
            string currLangString = PlayerPrefs.GetString(keyPref, "default");
            if (currLangString.Equals("default"))
            {
                SetLang(ConvertSystemLanguage(Application.systemLanguage));
            }
            else
            {
                Language code = (Language) Enum.Parse(typeof(Language), currLangString);
                SetLang(code);
            }
        }

        public static void SetLang(Language code)
        {
            Language = code;
            stringsDict = LanguageXmlReader.Read(rootPath, code);
            
            PlayerPrefs.SetString(keyPref, code.ToString());
            PlayerPrefs.Save();
            
            if (OnChangedLanguage != null) OnChangedLanguage(null, new LanguageEventArgs(code));
        }

        public static string GetText(string key)
        {
            if (stringsDict.ContainsKey(key))
            {
                string text = stringsDict[key];
                
                //need to support Rich text
                text = text.Replace("&lt;", "<");
                text = text.Replace("&gt;", ">");
                text = text.Replace("&amp;", "&");
                
                return text;
            }

            return key;
        }

        public static Sprite GetSprite(string key)
        {
            Sprite sprite = Resources.Load<Sprite>(rootPath + Language.ToString() + "/" + key);
            if (sprite == null)
            {
                Debug.LogWarning("Sprite " + key + " not found in " + Language.ToString() + " language");
            }
            return sprite;
        }

        public static Language ConvertSystemLanguage(SystemLanguage selected)
        {
            switch (selected)
            {
                case SystemLanguage.English:
                    return Language.English;
                case SystemLanguage.Spanish:
                    return Language.Spanish;
                case SystemLanguage.Portuguese:
                    return Language.PortuguesePortugal;
                case SystemLanguage.Russian:
                    return Language.Russian;
                case SystemLanguage.Turkish:
                    return Language.Turkish;
                case SystemLanguage.German:
                    return Language.German;
                case SystemLanguage.Italian:
                    return Language.Italian;
                default:
                    return defaultLang;
            }
        }

        public static event EventHandler<LanguageEventArgs> OnChangedLanguage = delegate { };
    }
}