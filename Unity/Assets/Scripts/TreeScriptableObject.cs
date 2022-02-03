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

        public List<GameObject> Trees;

        public List<GameObject> ordererTree;

        public GameObject GetTree(string name)
        {
            GameObject res = Trees.First(GameObject => GameObject.name == name);
            if (res == null)
            {
                return null;
            }
            ordererTree.Add(res);
            return res;
        }

    }

}

