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
                text.text = Localizer.Instance.GetText(key);
            }
            else
            {
                Debug.LogWarning("Key in the UILangText component on " + gameObject.name + " is null or empty");
            }
        }
    }
}


