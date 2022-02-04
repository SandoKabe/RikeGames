using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace clicker
{
    [System.Serializable]
    public class GameState
    {
        [SerializeField]
        public int id;
        public string saveId;
        public float score;
        public float lvlclick;
        public float lvlauto;
        public int seed;
        public string design; // à sérialiser

        public UIInteractCanvas codeCanvas;

        

        // 'public' variables here ...
        public static GameState Instance;
        public GameState()
        {
            Instance = this;
            StateAPIClient.RETREIVE_DATA_DELEGATE += Parse;
            codeCanvas = GameObject.FindWithTag("Code").GetComponent<UIInteractCanvas>();
            StateAPIClient.PARSE_ERROR_DELEGATE += ParseError;

        }

        private void ShowCode()
        {

            
            codeCanvas.ShowCode();
            

            Debug.Log("-----CODE = " + GameState.Instance.saveId);
            // Enable UI Show code
        }

        public delegate void LoadingDelegate();
        static public event LoadingDelegate LOAD_DATA_DELEGATE;

        public string PrepareData()
        {
            //if (GAME_DATA_DELEGATE != null)
            //{
            //    GAME_DATA_DELEGATE();
            //}
            StateAPIClient.ON_SAVE_SUCCESS_DELEGATE += ShowCode;
            

            GenerateRandomCode(); // set saveId
            //score = 0;
            //lvlclick = 0;
            //lvlauto = 0;
            //seed = // Tiles
            // design // TreeSO
            

            //saveId = "ASEFTH";
            //score = 10;
            //lvlclick = 10;
            //lvlauto = 10;
            //seed = 10;
            //design = "pineA, pineB";

            return JsonUtility.ToJson(this);
        }

        private void GenerateRandomCode()
        {

            List<char> res = new List<char>();

            char[] CHAR1 = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (char)i).ToArray();
            char[] CHAR2 = "0123456789".ToCharArray();
            char[] CHARS = CHAR1.Concat(CHAR2).ToArray();

            for (int i = 0; i < 6; i++)
            {
                int pos = Random.Range(0, 35);
                res.Add(CHARS[pos]);
            }

            saveId = string.Join("", res);
            

        }

        public void Parse(string json)
        {
            if (json == "")
            {
                Debug.Log("Cannot retreive data");
                ParseError("Cannot retreive data");
                return;
            }
            GameState go = JsonUtility.FromJson<GameState>(json);
            Debug.Log("json " + json);
            Debug.Log("saveId " + go.saveId);
            
            if (LOAD_DATA_DELEGATE != null)
            {
                LOAD_DATA_DELEGATE();
               
            }
            // TODO
            // Attendre 2s
            // Hide Menu Loading
            codeCanvas.HideLoading();



            StateAPIClient.ON_SAVE_SUCCESS_DELEGATE -= ShowCode;
            StateAPIClient.RETREIVE_DATA_DELEGATE -= Parse;
            StateAPIClient.PARSE_ERROR_DELEGATE -= ParseError;

        }

        public void ParseError(string json)
        {
            codeCanvas.ShowError(json);
        }

    }
}

