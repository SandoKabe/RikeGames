using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clicker 
{
    public class ClickCounter : UpgradeLevel
    {
        // Start is called before the first frame update
        private void Start()
        {
            level = 0;
            nbResPerLevel = 1;

        }


        public override void SetResPerLevel(bool loading = false)
        {
            nbResPerLevel = Mathf.Pow(2, level);

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
        public override void SetLevel()
        {
            GameState.Instance.lvlclick = level;
        }
        public override void PutLevel() 
        {
            level = 0;
            level = GameState.Instance.lvlclick;
            SetResPerLevel(true);
        }

    }
}
