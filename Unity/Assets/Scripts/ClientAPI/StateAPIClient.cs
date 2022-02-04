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


        public static StateAPIClient Instance;
        public StateAPIClient()
        {
            Instance = this;

        }

        private string jsonSaveFile;

        public delegate void CallbackDelegate(string st); // Set up a generic delegate type.
        static public event CallbackDelegate RETREIVE_DATA_DELEGATE;
        static public event CallbackDelegate PARSE_ERROR_DELEGATE;

        public delegate void CbackDelegate(); // Set up a generic delegate type.
        static public event CbackDelegate ON_SAVE_SUCCESS_DELEGATE;

        private void Start()
        {
            GameState gm = new GameState();
        }
  
        public void Save()
        {

            jsonSaveFile = GameState.Instance.PrepareData();
            StartCoroutine(Upload(jsonSaveFile));

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

                    if (PARSE_ERROR_DELEGATE != null)
                    {
                        PARSE_ERROR_DELEGATE(request.error);
                    }

                }
                else
                {

                    if (ON_SAVE_SUCCESS_DELEGATE != null)
                    {
                        ON_SAVE_SUCCESS_DELEGATE();
                    }
                    
                }

            }

        }

        public void Load()
        {
            string st = GameState.Instance.saveId;
            StartCoroutine(Download(st));
        }

        IEnumerator Download(string id )
        {
            using (UnityWebRequest request = UnityWebRequest.Get("http://127.0.0.1:8000/api/gamesaves/" + id))
            {
                yield return request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    if (PARSE_ERROR_DELEGATE != null)
                    {
                        PARSE_ERROR_DELEGATE(request.error);
                    }

                }
                else
                {
                    if (RETREIVE_DATA_DELEGATE != null)
                    {
                        RETREIVE_DATA_DELEGATE(request.downloadHandler.text);
                    }

                }

            }

        }

    }

}
