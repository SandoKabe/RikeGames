using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace clicker
{
    public class UICounter : MonoBehaviour
    {
        public GameObject rike;
        protected AutoCounter autoCounter;
        protected ClickCounter clickCounter;
        
        // Start is called before the first frame update
        protected void Awake()
        {
            rike = GameObject.FindGameObjectWithTag("Rike");
            autoCounter = rike.GetComponent<AutoCounter>();
            clickCounter = rike.GetComponent<ClickCounter>();

            

            //content = GetComponent<Text>();
            
        }
        protected void OnDestroy()
        {
            UIManager.AUTO_LEVEL_CHANGE_DELEGATE -= IncreaseLevel;
        }
        public virtual void IncreaseLevel() { }

        protected virtual void InitContent() { }


    }
}
