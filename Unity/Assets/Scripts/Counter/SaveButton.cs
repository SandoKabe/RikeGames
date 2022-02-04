using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace clicker
{
    public class SaveButton : MonoBehaviour, IPointerClickHandler
    {
        StateAPIClient saveManager;
        GraphicRaycaster m_Raycaster;
        PointerEventData m_PointerEventData;
        EventSystem m_EventSystem;

        public delegate void GameDataDelegate();
        static public event GameDataDelegate GAME_DATA_DELEGATE;

        // Update is called once per frame
        void Update()
        {
            saveManager = transform.root.GetComponent<StateAPIClient>();  
            //Fetch the Raycaster from the GameObject (the Canvas)
            m_Raycaster = GetComponent<GraphicRaycaster>();
            //Fetch the Event System from the Scene
            m_EventSystem = GetComponent<EventSystem>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (GAME_DATA_DELEGATE != null)
            {
                GAME_DATA_DELEGATE();
            }
            saveManager.Save();

        }

    }
}
