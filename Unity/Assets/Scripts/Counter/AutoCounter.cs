using UnityEngine;

namespace clicker {
    public class AutoCounter : UpgradeLevel
    {
        // Manage Level Auto Counter
        private void Start()
        {
            level = 0;
            nbResPerLevel = 0;

        }

        protected override void SetResPerLevel(bool loading = false)
        {
            if (level == 0)
            {
                nbResPerLevel = 0;
            }
            if (level > 0 && level <= 10)
            {
                nbResPerLevel = Mathf.Pow(2, level - 1);

            }

            // Not update UI on loading GO is disable
            // In this case UI Auto will be update on Enable()
            if (!loading)
            {
                UIManager.Instance.UpdateAuto();
            }
  
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

        // Using for prepare saving data
        protected override void SetLevel() 
        { 
            GameState.Instance.lvlauto = level;
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

