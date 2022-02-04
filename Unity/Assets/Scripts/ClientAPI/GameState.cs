using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace clicker
{
    [System.Serializable]
    public class GameState
    {
        // Object Game Data Save
        [SerializeField]
        public int id;
        public string saveId;
        public float score;
        public float lvlclick;
        public float lvlauto;
        public int seed;
        public string design; // List of tree name

        // UI wich is interacting with Loading, Saving and Exception requests
        public UIInteractCanvas codeCanvas;

        public static GameState Instance;

        public GameState()
        {
            Instance = this;
            StateAPIClient.RETREIVE_DATA_DELEGATE += Parse;
            codeCanvas = GameObject.FindWithTag("Code").GetComponent<UIInteractCanvas>();
            StateAPIClient.PARSE_ERROR_DELEGATE += ParseError;

        }



        public delegate void LoadingDelegate();
        static public event LoadingDelegate LOAD_DATA_DELEGATE;

        // UI Showing the alpha-numeric code
        private void ShowCode()
        {

            codeCanvas.ShowCode();

        }

        // Prepare data before saving request
        public string PrepareData()
        {

            StateAPIClient.ON_SAVE_SUCCESS_DELEGATE += ShowCode;

            GenerateRandomCode();

            GameStateData gameStateData = new GameStateData();
            gameStateData.id = id;
            gameStateData.saveId = saveId;
            gameStateData.score = score;
            gameStateData.lvlclick = lvlclick;
            gameStateData.lvlauto = lvlauto;
            gameStateData.seed = seed;
            gameStateData.design = design;


            return JsonUtility.ToJson(gameStateData);

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

        // Convert json to Game State Data following load request
        private void Parse(string json)
        {

            if (json == "")
            {

                ParseError("Cannot retreive data");
                return;
            }

            GameStateData go = JsonUtility.FromJson<GameStateData>(json);

            id = go.id;
            saveId = go.saveId;
            score = go.score;
            lvlauto = go.lvlauto;
            lvlclick = go.lvlclick;
            seed = go.seed;
            design = go.design;


            if (LOAD_DATA_DELEGATE != null)
            {
                LOAD_DATA_DELEGATE();
               
            }

            // Hide Menu Loading
            codeCanvas.HideLoading();

            StateAPIClient.ON_SAVE_SUCCESS_DELEGATE -= ShowCode;
            StateAPIClient.RETREIVE_DATA_DELEGATE -= Parse;
            StateAPIClient.PARSE_ERROR_DELEGATE -= ParseError;

        }

        private void ParseError(string json)
        {
            codeCanvas.ShowError(json);
        }

        

        [System.Serializable]
        public struct GameStateData
        {
            [SerializeField]
            public int id;
            public string saveId;
            public float score;
            public float lvlclick;
            public float lvlauto;
            public int seed;
            public string design; // List of tree name

        }


    }
    
}