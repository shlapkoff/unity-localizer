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
            SetLocalizedText(Localizer.Instance.Language);
        }

        private void Start()
        {
            Localizer.OnChangedLanguage += SetLocalizedText;
        }

        private void OnDestroy()
        {
            Localizer.OnChangedLanguage -= SetLocalizedText;
        }

        private void SetLocalizedText(LangCode code)
        {
            text.text = Localizer.Instance.GetText(key);
        }
    }
}


