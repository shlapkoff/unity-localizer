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
            UpdateImage();
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
            UpdateImage();
        }

        private void UpdateImage()
        {
            if (!string.IsNullOrEmpty(key))
            {
                image.sprite = Localizer.GetSprite(key);
            }
            else
            {
                Debug.LogWarning("Key in the UILangImage component on " + gameObject.name + " is null or empty");
            }
        }
    }
}


