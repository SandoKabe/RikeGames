using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clicker
{
    public class DesignManager : MonoBehaviour
    {
        public TreeScriptableObject treeSO;
        public GameObject parentTree;

        public Tiles ground;

        GameObject tree;
        GameObject tile;

        public delegate void CallbackDelegate(); // Set up a generic delegate type.
        static public event CallbackDelegate BUY_DESIGN_DELEGATE;


        // Start is called before the first frame update
        private void Awake()
        {
            treeSO = TreeScriptableObject.Instance;
            ground = GameObject.FindGameObjectWithTag("Tiles").transform.root.GetComponent<Tiles>();
        }
        private void GetPine(string name)
        {
            if( !PlayerScore.TryToBuyTree())
            {
                return;
            }
            tree = Instantiate(treeSO.GetTree(name));
            if (GameObject.FindGameObjectWithTag("Tree") == null)
            {
                parentTree = Instantiate(new GameObject("Tree"));
                parentTree.tag = "Tree";
                parentTree.transform.position = Vector3.zero;

            } else
            {
                parentTree = GameObject.FindGameObjectWithTag("Tree");
            }
            tree.transform.parent = parentTree.transform;
            tile = ground.GetNextTile();
            tree.transform.position = tile.transform.position;
            ground.SetTree(tree, tile);
        }

        public void GetPineA()
        {
            GetPine("pineA");
        }
        public void GetPineB()
        {
            GetPine("pineB");
        }
        public void GetPineC()
        {
            GetPine("pineC");
        }
    }
}

