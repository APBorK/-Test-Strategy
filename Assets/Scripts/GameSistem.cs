using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameSistem : MonoBehaviour,IPointerDownHandler
{
    public static GameSistem instance;
    [SerializeField] private List<String> _boost;
    [SerializeField] private SpawnGameObgect _spawnGameObgect;
    [SerializeField] private GameObject _panel;
    private List<GameObject> _bots = new List<GameObject>(), _players = new List<GameObject>();
    private List<Transform> _items;


    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Click();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
           SceneManager.LoadScene("SampleScene");
        }
    }

    
    public void AddList(GameObject game,bool player)
    {
        if (player)
        {
            _players.Add(game);
        }
        else
        {
            _bots.Add(game);
        }
    }

    public void AddItem(List<Transform> game)
    {
        _items = game;
    }

    public void EndGames()
    {
        var botKill = 0;
        var playerKill = 0;
        List<GameObject> player = new List<GameObject>();
        List<GameObject> bot = new List<GameObject>();
        List<Transform> items = new List<Transform>();
        for (int i = 0; i <  _bots.Count; i++)
        {
            if (_bots[i].activeSelf == false)
            {
                botKill++;
            }
            else
            {
                bot.Add(_bots[i]);
            }
        }
        
        for (int i = 0; i < _players.Count; i++)
        {
            if (_players[i].activeSelf == false)
            {
                playerKill++;
                _items[i].gameObject.SetActive(false);
            }
            else
            {
                items.Add(_items[i]);
                player.Add(_players[i]);
            }
        }
        if (botKill == _bots.Count)
        {
            _panel.SetActive(true);
            _panel.GetComponentInChildren<TextMeshProUGUI>().text = "Победа!";
        }
        if (playerKill == _players.Count)
        {
            _panel.SetActive(true);
            _panel.GetComponentInChildren<TextMeshProUGUI>().text = "Вы проиграли!";
        }
        if (playerKill>0)
        {
            _players = player;
            _items = items;
        }
        if (botKill>0)
        {
            _bots.Clear();  
            _bots = bot;
        }
    }
    void Click()
    {
        Debug.Log(_bots.Count);
        _spawnGameObgect.SpawnItem(_items);
        for (int i = 0; i < _bots.Count; i++)
        {
            BoosterSing.instance.Boost(_boost[Random.Range(0, _boost.Count)],_players[Random.Range(0,_players.Count)]);
        }
        TestPoison();
    }

    void TestPoison()
    {
        for (int i = 0; i <  _bots.Count; i++)
        {
            var botDat = _bots[i].GetComponent<DateObject>();
            if (botDat.PoisonClose)
            {
                botDat.Damage(1);
                botDat.ClosedPoison();
                botDat.PoisonClose = false;
            }
        }

        for (int i = 0; i < _players.Count; i++)
        {
            var playerDate = _players[i].GetComponent<DateObject>();
            if (playerDate.PoisonClose)
            {
                playerDate.Damage(1);
                playerDate.ClosedPoison();
                playerDate.PoisonClose = false;
            }
            if (playerDate.DefActive)
            {
                playerDate.CloseDef++;
            }
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Click();
    }
}
