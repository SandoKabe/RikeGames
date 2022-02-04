using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace clicker
{
    public class LoadButton : MonoBehaviour, IPointerClickHandler
    {

        StateAPIClient saveManager;
        GraphicRaycaster m_Raycaster;
        PointerEventData m_PointerEventData;
        EventSystem m_EventSystem;

        public Button btn;

        // Update is called once per frame
        void Update()
        {
            saveManager = transform.root.GetComponent<StateAPIClient>();
            //Fetch the Raycaster from the GameObject (the Canvas)
            m_Raycaster = GetComponent<GraphicRaycaster>();
            //Fetch the Event System from the Scene
            m_EventSystem = GetComponent<EventSystem>();
            btn = btn.GetComponent<Button>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            btn.transform.parent.gameObject.SetActive(true); 
            //saveManager.Load();

        }

    }
}
