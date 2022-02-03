using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clicker {
    public class AutoCounter : UpgradeLevel
    {
        // Start is called before the first frame update
        private void Start()
        {
            level = 0;
            nbResPerLevel = 0;

        }

        public override void SetResPerLevel()
        {
            if (level == 0)
            {
                nbResPerLevel = 0;
            }
            if (level > 0 && level <= 10)
            {
                nbResPerLevel = Mathf.Pow(2, level - 1);

            }
            // Update nbResAuto
            UIManager.Instance.UpdateAuto();
            
        }

        public override void UpdateLevel()
        {
            if (level == 10)
            {
                return;
            }
            if (level >= 0 && level < 10)
            {
                level++;
            } else
            { 
                level = 0; 
            }
           
            SetResPerLevel();

        }

    }
}

