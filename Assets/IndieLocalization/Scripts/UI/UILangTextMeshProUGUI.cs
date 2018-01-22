//using TMPro;
using IndigoBunting.Lang.Stub; //remove this line if you use TextMeshPro
using UnityEngine;

namespace IndigoBunting.Lang
{
    public class UILangTextMeshProUGUI : MonoBehaviour
    {
        [SerializeField]
        private string key;
        
        private TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
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
            text.SetText(Localizer.Instance.GetText(key));
        }
    }
}


