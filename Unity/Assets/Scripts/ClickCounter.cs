using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clicker 
{
    // Manage Level Auto Counter
    public class ClickCounter : UpgradeLevel
    {
        private void Start()
        {
            level = 0;
            nbResPerLevel = 1;

        }

        protected override void SetResPerLevel(bool loading = false)
        {
            nbResPerLevel = Mathf.Pow(2, level);

            // Not update UI on loading GO is disable
            // In this case UI Click will be update on Enable()
            if (!loading)
            {
                UIManager.Instance.UpdateAuto();
            }
            
        }

        public override void UpdateLevel()
        {

            if (level >= 0 && level < 10)
            {
                level++;
            }
            SetResPerLevel();

        }

        // Using for prepare saving data
        protected override void SetLevel()
        {
            GameState.Instance.lvlclick = level;
        }

        // Using for update with loading data
        protected override void PutLevel() 
        {
            level = 0;
            level = GameState.Instance.lvlclick;
            SetResPerLevel(true);
        }

    }

}
