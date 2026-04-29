using UnityEngine;
using UnityEngine.UI;

namespace NuclearDecline
{
    public sealed class NuclearDeclineLanguageText : MonoBehaviour
    {
        public Text textUIComponent;
        public TextMesh textMeshComponent;
        [Space(10)]
        public string text;
        [Tooltip("RUSSIAN")]
        public string ru, en, tr, az, be, he, hy, ka, et, fr, kk, ky, lt, lv, ro, tg, tk, uk, uz, es, pt, ar, id, ja, it, de, hi;
        public int fontNumber;
        public Font uniqueFont;
        private int baseFontSize;

        private void Awake()
        {
            if (textUIComponent)
                baseFontSize = textUIComponent.fontSize;
            else if (textMeshComponent)
                baseFontSize = textMeshComponent.fontSize;
        }

        private void OnEnable()
        {
            GamePlatformBridge.PlatformChanged += HandlePlatformChanged;
            GamePlatformBridge.LanguageChanged += SwitchLanguage;
            SwitchLanguage(GamePlatformBridge.Localization.CurrentLanguage);
        }

        private void OnDisable()
        {
            GamePlatformBridge.PlatformChanged -= HandlePlatformChanged;
            GamePlatformBridge.LanguageChanged -= SwitchLanguage;
        }

        private void HandlePlatformChanged(IPlatformService platform)
        {
            SwitchLanguage(platform.Localization.CurrentLanguage);
        }

        public void SwitchLanguage(string lang)
        {
            for (int i = 0; i < Languages.Length; i++)
            {
                if (lang == LanguageNames[i])
                {
                    AssignTranslate(Languages[i]);
                    FontSizeCorrect();
                    return;
                }
            }

            AssignTranslate(en);
        }

        private void AssignTranslate(string translation)
        {
            if (string.IsNullOrEmpty(translation))
                return;

            if (textUIComponent)
                textUIComponent.text = translation;
            else if (textMeshComponent)
                textMeshComponent.text = translation;
        }

        private void FontSizeCorrect()
        {
            if (textUIComponent)
                textUIComponent.fontSize = baseFontSize;
            else if (textMeshComponent)
                textMeshComponent.fontSize = baseFontSize;
        }

        private static readonly string[] LanguageNames =
        {
            "ru", "en", "tr", "az", "be", "he", "hy", "ka", "et", "fr", "kk", "ky", "lt", "lv",
            "ro", "tg", "tk", "uk", "uz", "es", "pt", "ar", "id", "ja", "it", "de", "hi"
        };

        public string[] Languages
        {
            get
            {
                return new[]
                {
                    ru, en, tr, az, be, he, hy, ka, et, fr, kk, ky, lt, lv, ro, tg, tk, uk, uz, es,
                    pt, ar, id, ja, it, de, hi
                };
            }
            set
            {
                ru = value[0];
                en = value[1];
                tr = value[2];
                az = value[3];
                be = value[4];
                he = value[5];
                hy = value[6];
                ka = value[7];
                et = value[8];
                fr = value[9];
                kk = value[10];
                ky = value[11];
                lt = value[12];
                lv = value[13];
                ro = value[14];
                tg = value[15];
                tk = value[16];
                uk = value[17];
                uz = value[18];
                es = value[19];
                pt = value[20];
                ar = value[21];
                id = value[22];
                ja = value[23];
                it = value[24];
                de = value[25];
                hi = value[26];
            }
        }
    }
}
