using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace clicker
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Tree", fileName = "Tree.asset")]
    [System.Serializable]
    public class TreeScriptableObject : ScriptableObject
    {
        public static TreeScriptableObject Instance;

        public TreeScriptableObject()
        {
            Instance = this;
        }

        [SerializeField]
        public List<GameObject> Trees;
        public List<string> ordererTree;

        private void OnEnable()
        {
            GameState.LOAD_DATA_DELEGATE += UpdateOrderTree;
            SaveButton.GAME_DATA_DELEGATE += SetOrdererTree;

            ordererTree = new List<string>();
            ordererTree.Clear();
        }

        private void OnDestroy()
        {
            GameState.LOAD_DATA_DELEGATE -= UpdateOrderTree;
            SaveButton.GAME_DATA_DELEGATE -= SetOrdererTree;
        }

        public void SetOrdererTree()
        {
            GameState.Instance.design = string.Join(",", ordererTree);
        }

        public void UpdateOrderTree()
        {
            //List<string> list = JsonUtility.FromJson<List<string>>(GameState.Instance.design);
            //ordererTree
            // EN fonction des noms de la liste récupérer les prefab puis setter ordererTree
            ordererTree.Clear();
            ordererTree = new List<string>(GameState.Instance.design.Split(',')); // JsonUtility.FromJson<List<GameObject>>(json);
        }

        public GameObject GetTree(string name, bool loading = false)
        {
            GameObject res = Trees.First(GameObject => GameObject.name == name);
            if (res == null)
            {
                return null;
            }
            if (!loading)
            {
                ordererTree.Add(res.name);
            }
            
            return res;
        }
        // Pas utilisé
        public void ParseTree(string json)
        {
            if (json == "")
            {
                Debug.Log("Cannot retreive trees");
            }
            //ordererTree = new List<string>(names.Split(',')); // JsonUtility.FromJson<List<GameObject>>(json);
            // List<string> listOfNames = new List<string>(names.Split(','));
            Debug.Log("Tree json " + json);
            Debug.Log("TRee first " + ordererTree.First());

        }



    }

}

