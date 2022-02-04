using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace clicker
{
    public class LoadButton : MonoBehaviour, IPointerClickHandler
    {
        // Using to set Loading Button behavior
        StateAPIClient saveManager;
        GraphicRaycaster m_Raycaster;
        PointerEventData m_PointerEventData;
        EventSystem m_EventSystem;

        // Loading Button to set alpha-numeric code
        [SerializeField] private Button loadingBtn;

        // Update is called once per frame
        void Update()
        {
            saveManager = transform.root.GetComponent<StateAPIClient>();
            //Fetch the Raycaster from the GameObject (the Canvas)
            m_Raycaster = GetComponent<GraphicRaycaster>();
            //Fetch the Event System from the Scene
            m_EventSystem = GetComponent<EventSystem>();
            loadingBtn = loadingBtn.GetComponent<Button>();

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            loadingBtn.transform.parent.gameObject.SetActive(true); 

        }

    }

}
