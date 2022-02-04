using System.Collections.Generic;
using UnityEngine;

namespace clicker
{
    public class DesignManager : MonoBehaviour
    {
        // Use to display Tree on scene
        [SerializeField] private TreeScriptableObject treeSO;
        [SerializeField] private GameObject parentTree;

        [SerializeField] private Tiles ground;

        GameObject tree;
        GameObject tile;

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

        // Update Pine on loading data
        public void LoadPine()
        {
            // Clean current scene
            ResetTree();

            List<string> ordererTree = treeSO.ordererTree;
            int seed = ground.initialSeed;
            ground.SetRandomInitState(seed);
            ordererTree.ForEach(x => GetPine(x, true));

        }

        private void ResetTree()
        {
            if (GameObject.FindGameObjectWithTag("Tree") != null)
            {
                GameObject del = GameObject.FindGameObjectWithTag("Tree");
                DestroyImmediate(del);

            }

        }

    }

}

