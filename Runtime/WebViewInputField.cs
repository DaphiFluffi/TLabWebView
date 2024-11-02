using UnityEngine;
using TLab.VKeyborad;
using System.Runtime.InteropServices.WindowsRuntime;

namespace TLab.Android.WebView
{
    public class WebViewInputField : InputFieldBase
    {
        [Header("WebView")]
        [SerializeField] private TLabWebView m_webview;

        #region KEY_EVENT

        public override void OnBackSpacePressed() => m_webview.BackSpace();

        public override void OnEnterPressed() => AddKey("\n");

        public override void OnSpacePressed() => AddKey(" ");

        public override void OnTabPressed()
        {
            return;
        }

        public override void OnKeyPressed(string input) => AddKey(input);

        public  void OnUpArrowPressed() => m_webview.UpArrow();

        public  void OnDownArrowPressed() => m_webview.DownArrow();
        public  void OnLeftArrowPressed() => m_webview.LeftArrow();
        public  void OnRightArrowPressed() => m_webview.RightArrow();


        #endregion KEY_EVENT

        public override void OnFocus()
        {
            var notActive = !inputFieldIsActive;

            if (m_keyborad.mobile && notActive)
            {
                m_keyborad.SwitchInputField(this);
                m_keyborad.SetVisibility(true);
            }
        }

        public void AddKey(string key)
        {
            m_webview.KeyEvent(key.ToCharArray()[0]);
        }

        public void UpArroww()
        {
            m_webview.UpArrow();
        }
    }
}
