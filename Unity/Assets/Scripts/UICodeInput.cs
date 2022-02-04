using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace clicker
{
    public class UICodeInput : MonoBehaviour, IPointerClickHandler
    {
        public InputField input;
        public Image loading;
        // Start is called before the first frame update
        void Start()
        {
            loading = loading.GetComponent<Image>();
            input = input.GetComponent<InputField>();
            loading.gameObject.SetActive(false);
            gameObject.transform.parent.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnPointerClick(PointerEventData eventData)
        {

            string code = input.text.ToString();
            if (string.IsNullOrEmpty(code))
            {
                return;
            }
            GameState.Instance.saveId = code;
            StateAPIClient.Instance.Load();
            loading.gameObject.SetActive(true);
            this.gameObject.transform.parent.gameObject.SetActive(false);
    
    }

    }
}

