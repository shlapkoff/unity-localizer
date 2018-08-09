using UnityEngine;
using UnityEngine.UI;

namespace IndigoBunting.Lang
{
    [RequireComponent(typeof(Text))]
    public class UILangText : MonoBehaviour
    {
        [SerializeField]
        private string key;
        
        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
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
                text.text = Localizer.GetText(key);
            }
            else
            {
                Debug.LogWarning("Key in the UILangText component on " + gameObject.name + " is null or empty");
            }
        }
    }
}


