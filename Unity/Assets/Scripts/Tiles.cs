using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;

namespace clicker
{
    public class Tiles : MonoBehaviour
    {
        Random.State lastState;
        GameObject[] tiles;

        Dictionary<float, GameObject> tilesDict;
        List<float> indexList;
        List<GameObject> tileList;
        List<TileObj> tileObjs;

        // Start is called before the first frame update
        void Start()
        {
            tiles = new GameObject[56];
            tiles = GameObject.FindGameObjectsWithTag("Tiles");
            indexList = new List<float>();
            tileObjs = new List<TileObj>();

            int initialSeed = PlayerPrefs.GetInt("seed", 100);
            if (initialSeed == 100)
            {
                initialSeed = Random.Range(0, 100);
            }

            PlayerPrefs.SetInt("seed", initialSeed);
            Random.InitState(initialSeed);

            for (int i = 0; i < tiles.Length; i++)
            {
                indexList.Add(Random.value);

            }

            indexList.Sort();
            // Associer les tuiles à ma liste

            for (int i = 0; i < tiles.Length; i++)
            {
                tileObjs.Add(new TileObj(indexList[i], tiles[i], null));
            }

            Random.InitState(initialSeed);

        }

        public GameObject GetNextTile()
        {
            float res = Random.value;
            TileObj query = tileObjs.First(TileObj => TileObj.index == res);
            GameObject tile = query.tile;
            return tile;
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
