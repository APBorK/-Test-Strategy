using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class SpawnGameObgect : MonoBehaviour
{
    [SerializeField] 
    private GameObject _gameObject,_createItems;
    [SerializeField]
    private List<Transform> _botSpawnPosition, _playerSpawnPosition,_itemSpawnPosition;

    private void Start()
    {
        SpawnObject(_botSpawnPosition,false);
        SpawnObject(_playerSpawnPosition,true);
        SpawnItem(_itemSpawnPosition);
        GameSistem.instance.AddItem(_itemSpawnPosition);
    }

    private void SpawnObject(List<Transform> positions,bool player)
    {
        var gameObgect = new GameObject();
        for (int i = 0; i < positions.Count; i++)
        {
            gameObgect = Instantiate(_gameObject,positions[i]);
            gameObgect.GetComponent<Image>().sprite = Resources.Load<Sprite>("Player/" + Random.Range(1,48));
            GameSistem.instance.AddList(gameObgect,player);
        }
    }

    public void SpawnItem(List<Transform> positions)
    {
        for (int i = 0; i < positions.Count; i++)
        {
           Instantiate(_createItems,positions[i]);
        }
    }
}
