using UnityEngine;
using UnityEngine.UI;

namespace IndigoBunting.Lang
{
    public class UILangText : MonoBehaviour
    {
        [SerializeField]
        private string key;
        
        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        private void OnEnable()
        {
            Localizer.Instance.OnChangedLanguage += Localizer_OnChangedLanguage;
        }

        private void OnDisable()
        {
            Localizer.Instance.OnChangedLanguage -= Localizer_OnChangedLanguage;
        }

        private void Localizer_OnChangedLanguage(LangCode code)
        {
            text.text = Localizer.Instance.GetText(key);
        }
    }
}


