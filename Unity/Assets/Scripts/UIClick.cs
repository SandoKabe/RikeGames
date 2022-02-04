using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace clicker
{
    public class UIClick : UICounter
    {
        private Text contentRes;
        private Text contentLev;
        protected void Start()
        {

            UIManager.CLICK_LEVEL_CHANGE_DELEGATE += IncreaseLevel;
            contentRes = GameObject.FindWithTag("Resource").GetComponent<Text>();
            contentLev = GameObject.FindWithTag("Level").GetComponent<Text>();
            InitContent();

        }
        void OnAwake()
        {
            IncreaseLevel();
        }
        public override void IncreaseLevel()
        {
            contentLev.text = "lvl" + clickCounter.level.ToString() + ".";
            contentRes.text = clickCounter.nbResPerLevel.ToString() + " per click";

        }

        protected override void InitContent()
        {
            contentLev.text = "lvl 0.";
            contentRes.text = "1 per click";
        }

    }
}


