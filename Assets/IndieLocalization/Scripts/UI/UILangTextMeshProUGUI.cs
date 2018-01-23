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
            if (!string.IsNullOrEmpty(key))
            {
                text.SetText(Localizer.Instance.GetText(key));
            }
            else
            {
                Debug.LogWarning("Key in the UILangTextMeshProUGUI component on " + gameObject.name + " is null or empty");
            }
        }
    }
}


