//using TMPro;
using IndigoBunting.Lang.Stub; //remove this line if you use TextMeshPro
using UnityEngine;

namespace IndigoBunting.Lang
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class UILangTextMeshProUGUI : MonoBehaviour
    {
        [SerializeField]
        private string key;
        
        private TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            UpdateText();
        }

        private void Start()
        {
            Localizer.OnChangedLanguage += Localizer_OnChangedLanguage;
        }

        private void OnDestroy()
        {
            Localizer.OnChangedLanguage -= Localizer_OnChangedLanguage;
        }

        private void Localizer_OnChangedLanguage(object sender, LanguageEventArgs e)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            if (!string.IsNullOrEmpty(key))
            {
                text.SetText(Localizer.GetText(key));
            }
            else
            {
                Debug.LogWarning("Key in the UILangTextMeshProUGUI component on " + gameObject.name + " is null or empty");
            }
        }
    }
}


