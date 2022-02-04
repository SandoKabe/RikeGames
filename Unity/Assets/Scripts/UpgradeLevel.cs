using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clicker
{
    public class UpgradeLevel : MonoBehaviour
    {
        public enum UpgradeTypes
        {
            CLICK,
            AUTO
        }
        // Private
        [SerializeField]
        public UpgradeTypes type { get; set; }

        // Public 
        [SerializeField]
        public float level { get; set; }
        //public float clickLevel;// { get; set; }   
        public float nbResPerLevel;// { get; set; }    // Qui depend du type

        public delegate void CallbackDelegate(); // Set up a generic delegate type.
        static public event CallbackDelegate LEVEL_CHANGE_DELEGATE;
        static public event CallbackDelegate RES_CHANGE_DELEGATE;

        protected void Awake()
        {
            SaveButton.GAME_DATA_DELEGATE += SetLevel;
            GameState.LOAD_DATA_DELEGATE += UpdateLevel;
        }

        protected void Start()
        {
            level = 0;
            nbResPerLevel = 0;
            

        }

        protected void OnDestroy()
        {
            SaveButton.GAME_DATA_DELEGATE -= SetLevel;
            GameState.LOAD_DATA_DELEGATE -= PutLevel;
        }

        public virtual void SetLevel() { }

        public virtual void PutLevel() { }

        public virtual void SetResPerLevel(bool loading = false) { }

        public virtual void UpdateLevel() { }


    }


}

