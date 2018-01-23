using UnityEngine;
using UnityEngine.UI;

namespace IndigoBunting.Lang
{
    [RequireComponent(typeof(Image))]
    public class UILangImage : MonoBehaviour
    {
        [SerializeField]
        private string key;
        
        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
            SetLocalizedSprite(Localizer.Instance.Language);
        }

        private void Start()
        {
            Localizer.OnChangedLanguage += SetLocalizedSprite;
        }

        private void OnDestroy()
        {
            Localizer.OnChangedLanguage -= SetLocalizedSprite;
        }

        private void SetLocalizedSprite(LangCode code)
        {
            if (!string.IsNullOrEmpty(key))
            {
                image.sprite = Localizer.Instance.GetSprite(key);
            }
            else
            {
                Debug.LogWarning("Key in the UILangImage component on " + gameObject.name + " is null or empty");
            }
        }
    }
}


