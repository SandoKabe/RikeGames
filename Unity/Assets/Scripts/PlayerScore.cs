using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace clicker
{
    public class PlayerScore : MonoBehaviour
    {

        // Static
        //public static PlayerScore Instance;

        public GameObject rike;
        private AutoCounter autoCounter;
        private ClickCounter clickCounter;

        [SerializeField] private TMP_Text _textbox;
        const float LEVEL_PRICE = 20;

        // A remettre en private just for test
        private float _score;
        
        private float Score { get { return _score; } }

        public float TotalResFor5s { get; private set; }


        private void OnEnable()
        {
            _textbox.SetText(_score.ToString());
        }

        private void Start()
        {
            rike = GameObject.FindGameObjectWithTag("Rike");
            autoCounter = rike.GetComponent<AutoCounter>();
            clickCounter = rike.GetComponent<ClickCounter>();


            // Instance = this;
            StartCoroutine(IncrementPassiveRes());
           // initUpgrageSO();

            // Register this callback with the static public events 
            UIManager.AUTO_LEVEL_CHANGE_DELEGATE += UpdateLevel;  
            UIManager.CLICK_LEVEL_CHANGE_DELEGATE += UpdateLevelClick;
            SaveButton.GAME_DATA_DELEGATE += SetScore;
            GameState.LOAD_DATA_DELEGATE += UpdateScore;



        }

        protected void OnDestroy()
        {
            // Unregister this callback from the static public events on AsteraX.
            UIManager.AUTO_LEVEL_CHANGE_DELEGATE -= UpdateLevel;
            UIManager.CLICK_LEVEL_CHANGE_DELEGATE -= UpdateLevelClick;
            SaveButton.GAME_DATA_DELEGATE -= SetScore;
            GameState.LOAD_DATA_DELEGATE -= UpdateScore;
            //UIManager.CLICK_LEVEL_CHANGE_DELEGATE -= upLevelClickSO.UpdateLevel;



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
                TotalResFor5s = autoCounter.nbResPerLevel; // Dépend du level auto 
                IncreaseTotalRes(TotalResFor5s);
            }
        }
        public void IncreaseScore()
        {
            _score += clickCounter.nbResPerLevel;
            _textbox.SetText(_score.ToString());
        }

        public bool TryToDecreaseScore()
        {
            if (_score >= LEVEL_PRICE)
            {
                _score -= LEVEL_PRICE;
                return true;
            }
            return false;
            
        }

        public void IncreaseTotalRes(float totalResFor5s)
        {
            _score += totalResFor5s;
            _textbox.SetText(_score.ToString());
        }
        
        public void UpdateLevel()
        {
            // Player score
            // décrémenter le score
            // Mettre à jour le level dans le scriptable object 


            bool res = TryToDecreaseScore();
            if (res)
            {
                autoCounter.UpdateLevel();
            }  
        }
        public void UpdateLevelClick()
        {
            // Player score
            // décrémenter le score
            // Mettre à jour le level dans le scriptable object 


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
