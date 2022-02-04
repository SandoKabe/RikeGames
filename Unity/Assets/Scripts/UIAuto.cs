using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace clicker
{
    public class UIAuto : UICounter
    {
        private Text contentRes;
        private Text contentLev;
        protected void Start()
        {
            
            UIManager.AUTO_LEVEL_CHANGE_DELEGATE += IncreaseLevel;
            contentRes = GameObject.FindWithTag("ResA").GetComponent<Text>();
            contentLev = GameObject.FindWithTag("LevelA").GetComponent<Text>();
            InitContent();

        }

        void OnAwake()
        {
            IncreaseLevel();
        }
        //TODO Placer l'update du texte dans l'ojet UpgradeLevel de manière à ce qu'il soit mis à jour après le level
        // idem pour le UILEvel click et auto
        public override void IncreaseLevel()
        {
            contentLev.text = "lvl" + autoCounter.level.ToString() + ".";
            contentRes.text = autoCounter.nbResPerLevel.ToString() + " per click";

        }

        protected override void InitContent()
        {
            contentLev.text = "lvl0.";
            contentRes.text = "0 per click";
        }

        

    }
}

