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

        private void Start()
        {
            GameState.LOAD_DATA_DELEGATE += LoadPine;

        }

        private void OnDestroy()
        {
            GameState.LOAD_DATA_DELEGATE -= LoadPine;
        }
        private void GetPine(string name, bool loading = false)
        {
            if (!PlayerScore.TryToBuyTree() && !loading)
            {
                return;
            }
            
            if (GameObject.FindGameObjectWithTag("Tree") == null)
            {
                parentTree = Instantiate(new GameObject("Tree"));
                parentTree.tag = "Tree";
                parentTree.transform.position = Vector3.zero;

            }
            else
            {
                parentTree = GameObject.FindGameObjectWithTag("Tree");
            }
            tree = Instantiate(treeSO.GetTree(name, loading));
            tree.transform.parent = parentTree.transform;
            tile = ground.GetNextTile();
            if (tile != null)
            {
                tree.transform.position = tile.transform.position;
                ground.SetTree(tree, tile);
            }
            
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
        public void LoadPine()
        {

            // get tileObjs 
            // get Tileslist
            // get seed
            // initstate
            // foreach tree in list instatiate with the tiles
            ResetTree();

            List<string> ordererTree = treeSO.ordererTree;
            int seed = ground.initialSeed;
            ground.SetRandomInitState(seed);
            ordererTree.ForEach(x => GetPine(x, true));

        }

        public void ResetTree()
        {
            if (GameObject.FindGameObjectWithTag("Tree") != null)
            {
                GameObject del = GameObject.FindGameObjectWithTag("Tree");
                Destroy(del);

            }

        }
    }
}

