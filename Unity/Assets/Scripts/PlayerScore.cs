using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace clicker
{
    public class PlayerScore : MonoBehaviour
    {

        [SerializeField] private GameObject rike;
        private AutoCounter autoCounter;
        private ClickCounter clickCounter;

        [SerializeField] private TMP_Text _textbox;
        const float LEVEL_PRICE = 20;

        private float _score;
        
        private float Score { get { return _score; } }

        private float TotalResFor5s;


        private void OnEnable()
        {
            _textbox.SetText(_score.ToString());
        }

        private void Start()
        {
            rike = GameObject.FindGameObjectWithTag("Rike");
            autoCounter = rike.GetComponent<AutoCounter>();
            clickCounter = rike.GetComponent<ClickCounter>();


            StartCoroutine(IncrementPassiveRes());

            // Register this callback with the static public events 
            UIManager.AUTO_LEVEL_CHANGE_DELEGATE += UpdateLevel;  
            UIManager.CLICK_LEVEL_CHANGE_DELEGATE += UpdateLevelClick;
            SaveButton.GAME_DATA_DELEGATE += SetScore;
            GameState.LOAD_DATA_DELEGATE += UpdateScore;

        }

        protected void OnDestroy()
        {
            UIManager.AUTO_LEVEL_CHANGE_DELEGATE -= UpdateLevel;
            UIManager.CLICK_LEVEL_CHANGE_DELEGATE -= UpdateLevelClick;
            SaveButton.GAME_DATA_DELEGATE -= SetScore;
            GameState.LOAD_DATA_DELEGATE -= UpdateScore;

        }

        private void SetScore()
        {
            GameState.Instance.score = Score;
        }

        private void UpdateScore()
        {
            _score = GameState.Instance.score;
        }

        #region Increment
        IEnumerator IncrementPassiveRes()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f);
                TotalResFor5s = autoCounter.nbResPerLevel; // Depend of auto level
                IncreaseTotalRes(TotalResFor5s);

            }

        }
        private void IncreaseScore()
        {
            _score += clickCounter.nbResPerLevel;
            _textbox.SetText(_score.ToString());
        }

        private bool TryToDecreaseScore()
        {
            if (_score >= LEVEL_PRICE)
            {
                _score -= LEVEL_PRICE;
                return true;
            }
            return false;
            
        }

        private void IncreaseTotalRes(float totalResFor5s)
        {
            _score += totalResFor5s;
            _textbox.SetText(_score.ToString());
        }

        // Decrease score and ask for update auto level
        private void UpdateLevel()
        {
            bool res = TryToDecreaseScore();
            if (res)
            {
                autoCounter.UpdateLevel();
            }  

        }

        // Decrease score and ask for update click level
        private void UpdateLevelClick()
        {

            bool res = TryToDecreaseScore();
            if (res)
            {
                clickCounter.UpdateLevel();
            }
        }

        
        public static bool TryToBuyTree()
        {
            return PlayerScore.Instance.TryToDecreaseScore();

        }

        public static PlayerScore Instance;
        public PlayerScore()
        {
            Instance = this;
        }

        #endregion

    }
}
