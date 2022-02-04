using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace clicker
{
    public class UIRetCodeInput : MonoBehaviour, IPointerClickHandler
    {
        public InputField input;

        // Start is called before the first frame update
        void Start()
        {
            input = input.GetComponentInChildren<InputField>();
            gameObject.transform.parent.gameObject.SetActive(false);

        }

        void OnEnable()
        {
            ShowInput();
        }

        public void ShowInput()
        {
            if (GameState.Instance != null)
            {
                input.text = GameState.Instance.saveId;
            }
            
        }
        public void OnPointerClick(PointerEventData eventData)
        {

            this.gameObject.transform.parent.gameObject.SetActive(false);

        }

    }
}
