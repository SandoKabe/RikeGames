using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace clicker
{

    public class StateAPIClient : MonoBehaviour
    {

        //static private GameState saveFile;

        public static StateAPIClient Instance;
        public StateAPIClient()
        {
            Instance = this;
            

        }

        public string jsonSaveFile;


        //public GameObject rike;
        //protected AutoCounter autoCounter;
        //protected ClickCounter clickCounter;

        public delegate void CallbackDelegate(string st); // Set up a generic delegate type.
        static public event CallbackDelegate RETREIVE_DATA_DELEGATE;
        static public event CallbackDelegate PARSE_ERROR_DELEGATE;

        public delegate void CbackDelegate(); // Set up a generic delegate type.
        static public event CbackDelegate ON_SAVE_SUCCESS_DELEGATE;


        private void Start()
        {
            GameState gm = new GameState();
        }
            //    //cb += GameState.Test;
            //    //rike = GameObject.FindGameObjectWithTag("Rike");
            //    //autoCounter = rike.GetComponent<AutoCounter>();
            //    //clickCounter = rike.GetComponent<ClickCounter>();

            //    //saveFile = new GameState();

            //     // A mettre ailleurs si possible
            //       // A mettre ailleurs si possible
            //    //StartProcess();
            //    // StartCoroutine(LoadScene());
            //    //Call the LoadButton() function when the user clicks this Button
            //    // m_Button.onClick.AddListener(LoadButton);


            //}
            //private void OnDestroy()
            //{

            //    PARSE_ERROR_DELEGATE -= ParseError;   // A mettre ailleurs si possible
            //}



            public void Save()
        {
            // PrepareData();
            jsonSaveFile = GameState.Instance.PrepareData();

            // Serialize Json

            StartCoroutine(Upload(jsonSaveFile));


            // Wait Result
            // Return result

        }

        IEnumerator Upload(string data) // TODO Delegate to show id Save

        {

            using (UnityWebRequest request = new UnityWebRequest("http://127.0.0.1:8000/api/gamesaves/" , "POST"))

            {

                request.SetRequestHeader("Content-Type", "application/json");

                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonSaveFile);

                request.uploadHandler = new UploadHandlerRaw(bodyRaw);

                request.downloadHandler = new DownloadHandlerBuffer();

                yield return request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)

                {

                    Debug.Log(request.error);

                    if (PARSE_ERROR_DELEGATE != null)
                    {
                        PARSE_ERROR_DELEGATE(request.error);
                    }

                    // Gestion d'erreur Throw Exception

                }

                else

                {

                    //if (callback != null)

                    //{

                    //    callback.Invoke(request.downloadHandler.text != "{}");

                    //}
                    if (request.downloadHandler.text != "{}")
                    {
                        Debug.Log("Cannot retreive Data");
                    }
                    // TODO
                    // Add method to show UI with code GameState.SaveId
                    if (ON_SAVE_SUCCESS_DELEGATE != null)
                    {
                        ON_SAVE_SUCCESS_DELEGATE();
                    }
                    
                }

            }
        }

        public void Load()
        {
            string st = GameState.Instance.saveId; /// Get input code
            StartCoroutine(Download(st)); // Récupérer idSave;
        }

        IEnumerator Download(string id )

        {

            using (UnityWebRequest request = UnityWebRequest.Get("http://127.0.0.1:8000/api/gamesaves/" + id)) // Trouver la bonne formule

            {

                yield return request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)

                {

                    Debug.Log(request.error);
                    if (PARSE_ERROR_DELEGATE != null)
                    {
                        PARSE_ERROR_DELEGATE(request.error);
                    }

                    //if (callback != null)

                    //{

                    //    callback.Invoke(null);

                    //}

                }

                else

                {

                    //if (callback != null)

                    //{
                    if (RETREIVE_DATA_DELEGATE != null)
                    {
                        RETREIVE_DATA_DELEGATE(request.downloadHandler.text);
                    }
                    
                       // callback.Invoke(GameState.Parse(request.downloadHandler.text)); //Add object return;

                    //}

                }

            }

        }

    }

}
