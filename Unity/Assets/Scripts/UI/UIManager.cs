using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clicker
{
    public class UIManager : MonoBehaviour
    {
        GameObject upCanvas;
        GameObject menuCanvas;

        // Static
        public static UIManager Instance;

        public UIAuto uiAuto;
        public UIClick uiClick;

        

        public delegate void CallbackDelegate(); // Set up a generic delegate type.
        static public event CallbackDelegate AUTO_LEVEL_CHANGE_DELEGATE;
        static public event CallbackDelegate CLICK_LEVEL_CHANGE_DELEGATE;

        

        private bool toggle;
        private float currentScore;
        private float currentLevelPrice;


        private void Awake()
        {
            Instance = this;
            uiAuto = GetComponentInChildren<UIAuto>();
            uiClick = GetComponentInChildren<UIClick>();

            upCanvas = GameObject.FindGameObjectWithTag("UpgradePanel");
            menuCanvas = GameObject.FindGameObjectWithTag("MenuPanel");

        }
        protected void Start()
        {
            upCanvas.SetActive(toggle);
            menuCanvas.SetActive(!toggle);
        }

        public void ToggleUpgradeMenu()
        {
            toggle = !toggle;
            upCanvas.SetActive(toggle);
            menuCanvas.SetActive(!toggle);

        }

        public void ConsumeResourcesAuto() // Une pour chaque Upgrade
        {

                // level ++

                // Créer un delegate 
                // S'y abonner dans les objets ci-dessous
                if (AUTO_LEVEL_CHANGE_DELEGATE != null)
                {
                    AUTO_LEVEL_CHANGE_DELEGATE();
                }


                // Player score
                // Mettre à jour le level dans le scriptable object 
                // décrémenter le score

                // UI AUTO
                // Mettre à jour le level dans l'UI

        }

        public void ConsumeResourcesClick()
        {
            if (CLICK_LEVEL_CHANGE_DELEGATE != null)
            {
                CLICK_LEVEL_CHANGE_DELEGATE();
            }
        }

        

        public void UpdateAuto() //float level, float nbResPerLevel
        {
            uiAuto.IncreaseLevel();
        }

        public void UpdateClick() 
        {
            uiClick.IncreaseLevel();
        }

    }
}
