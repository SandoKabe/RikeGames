using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace clicker
{
    // Menu Button use to show Upgrade Menu
    public class ButtonClicker : MonoBehaviour, IPointerClickHandler
    {

        GraphicRaycaster m_Raycaster;
        PointerEventData m_PointerEventData;
        EventSystem m_EventSystem;

        // Update is called once per frame
        void Update()
        {
            //Fetch the Raycaster from the GameObject (the Canvas)
            m_Raycaster = GetComponent<GraphicRaycaster>();
            //Fetch the Event System from the Scene
            m_EventSystem = GetComponent<EventSystem>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UIManager.Instance.ToggleUpgradeMenu();

        }

    }

}
