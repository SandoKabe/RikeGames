using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace clicker
{

    public class SaveGameManager : MonoBehaviour
    {

        static private SaveFile saveFile;

        public string jsonSaveFile;


        public GameObject rike;
        protected AutoCounter autoCounter;
        protected ClickCounter clickCounter;


        private void Start()
        {
            rike = GameObject.FindGameObjectWithTag("Rike");
            autoCounter = rike.GetComponent<AutoCounter>();
            clickCounter = rike.GetComponent<ClickCounter>();

            saveFile = new SaveFile();
            //StartProcess();
            // StartCoroutine(LoadScene());
            //Call the LoadButton() function when the user clicks this Button
            // m_Button.onClick.AddListener(LoadButton);
            Save();
        }

        public void Save()
        {
            // PrepareData();

            saveFile.levelCounterAuto = autoCounter.level;
            saveFile.levelCounterClick = clickCounter.level;
            saveFile.idSave = "AZERTY"; // getfrom input

            jsonSaveFile = JsonUtility.ToJson(saveFile, true);

            // Serialize Json

            StartCoroutine(Upload(jsonSaveFile));


            // Wait Result
            // Return result

        }

        IEnumerator Upload(string data, System.Action<bool> callback = null) // TODO Delegate to show id Save

        {

            using (UnityWebRequest request = new UnityWebRequest("http://localhost/index.php", "POST"))

            {

                request.SetRequestHeader("Content-Type", "application/json");

                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonSaveFile);

                request.uploadHandler = new UploadHandlerRaw(bodyRaw);

                request.downloadHandler = new DownloadHandlerBuffer();

                yield return request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)

                {

                    Debug.Log(request.error);

                    if (callback != null)

                    {

                        callback.Invoke(false);

                    }

                }

                else

                {

                    if (callback != null)

                    {

                        callback.Invoke(request.downloadHandler.text != "{}");

                    }

                }

            }
        }

        public void Load()
        {
            string st = "AZERTY";
            StartCoroutine(Download(st)); // Récupérer idSave;
        }

        IEnumerator Download(string id, System.Action<SaveFile> callback = null)

        {

            using (UnityWebRequest request = UnityWebRequest.Get("http://localhost/index.php"))

            {

                yield return request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)

                {

                    Debug.Log(request.error);

                    if (callback != null)

                    {

                        callback.Invoke(null);

                    }

                }

                else

                {

                    if (callback != null)

                    {

                        callback.Invoke(SaveFile.Parse(request.downloadHandler.text)); //Add object return;

                    }

                }

            }

        }

    }

public class SaveFile
{
    public string idSave = "AZERTY";
    public float levelCounterClick;
    public float levelCounterAuto;

        // 'public' variables here ...

        public string Stringify()

        {

            return JsonUtility.ToJson(this);

        }

        public static SaveFile Parse(string json)

        {

            return JsonUtility.FromJson<SaveFile>(json);

        }
    }

    


}
