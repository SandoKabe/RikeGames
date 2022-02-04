using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace clicker
{
    public class UIInteractCanvas : MonoBehaviour
    {
        public UIRetCodeInput btnResCode;
        public Button btnInputCode;
        public Image loading;
        public Image error;

       void Start()
        {
            btnResCode = btnResCode.GetComponent<UIRetCodeInput>();
            loading = loading.GetComponent<Image>();
            error = error.GetComponent<Image>();
            error.gameObject.SetActive(false);

        }

        public void ShowCode()
        {
            btnResCode.transform.parent.gameObject.SetActive(true);
            btnResCode.ShowInput();
        }

        public void HideLoading()
        {
            StartCoroutine(JustWait());
        }

        IEnumerator JustWait()
        {
            int t = 3;
            yield return new WaitForSeconds(t);
            loading.gameObject.SetActive(false);
            error.gameObject.SetActive(false);
        }

        public void ShowError(string err)
        {
            error.gameObject.SetActive(true);
            error.GetComponentInChildren<Text>().text = err;
            StartCoroutine(JustWait());
        }
    }
}

