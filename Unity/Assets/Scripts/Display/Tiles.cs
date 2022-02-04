using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;

namespace clicker
{
    // Using to add an random index value on each tile and memorize them.
    public class Tiles : MonoBehaviour
    {
        Random.State lastState;
        GameObject[] tiles;

        Dictionary<float, GameObject> tilesDict;
        List<float> indexList;
        List<GameObject> tileList;
        List<TileObj> tileObjs;

        [SerializeField]
        public int initialSeed;

        private void Awake()
        {
            GameState.LOAD_DATA_DELEGATE += UpdateSeed;
            SaveButton.GAME_DATA_DELEGATE += SetSeed;
        }

        // Start is called before the first frame update
        void Start()
        {
            tiles = new GameObject[56];
            tiles = GameObject.FindGameObjectsWithTag("Tiles");
            indexList = new List<float>();
            tileObjs = new List<TileObj>();

            initialSeed = Random.Range(0, 100);

            InitTiles();

            SetRandomInitState(initialSeed);

        }

        private void OnDestroy()
        {
            GameState.LOAD_DATA_DELEGATE -= UpdateSeed;
            SaveButton.GAME_DATA_DELEGATE -= SetSeed;
        }

        private void InitTiles()
        {

            SetRandomInitState(initialSeed);
            indexList.Clear();
            tileObjs.Clear();
            for (int i = 0; i < tiles.Length; i++)
            {
                indexList.Add(Random.value);

            }

            indexList.Sort();

            // Associate Tiles and Random value
            for (int i = 0; i < tiles.Length; i++)
            {
                tileObjs.Add(new TileObj(indexList[i], tiles[i], null));
            }
        }

        private void SetSeed()
        {
            GameState.Instance.seed = initialSeed;
        }

        public void UpdateSeed()
        {
            initialSeed = GameState.Instance.seed;
            InitTiles();
        }

        public void SetRandomInitState(int seed)
        {
            Random.InitState(seed);
        }

        public GameObject GetNextTile()
        {
            TileObj query = null;
            float res = Random.value;
            try
            {
                query = tileObjs.First(TileObj => TileObj.index == res);
                GameObject tile = query.tile;
                return tile;
            } catch (System.InvalidOperationException e)
            {
                return null;
            }
            
            
        }

        public void SetTree(GameObject tree, GameObject tile)
        {
            TileObj query = tileObjs.First(TileObj => TileObj.tile == tile);
            query.tree = tree;

        }

    }

    public class TileObj
    {
        public float index;
        public GameObject tile;
        public GameObject tree;

        public TileObj(float idx, GameObject a, GameObject b) 
        { 

            index = idx;
            tile = a;
            tree = b;
        }

    }

}
