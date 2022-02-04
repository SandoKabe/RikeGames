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
            ordererTree.Clear();
            ordererTree = new List<string>(GameState.Instance.design.Split(','));
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

    }

}

