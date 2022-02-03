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

        protected void Start()
        {
            level = 0;
            nbResPerLevel = 0;
        }

        public virtual void SetResPerLevel() { }

        public virtual void UpdateLevel() { }


    }


}

