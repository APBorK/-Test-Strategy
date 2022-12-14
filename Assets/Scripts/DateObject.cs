using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateObject : MonoBehaviour
{
    [SerializeField] private Slider _sliderHP, _sliderDef;
    [SerializeField] private TextMeshProUGUI _textHP, _textDef;
    [SerializeField] private float _maxDef,_maxHP;
    [SerializeField] private GameObject _poison;
    [HideInInspector]
    public bool PoisonClose,DefActive;
    [HideInInspector]
    public int CloseDef;

    private void Start()
    {
        ClosedDef();
        ActiveHp();
        ClosedPoison();
    }

    private void Update()
    {
        if (CloseDef == 3)
        {
            CloseDef = 0;
            ClosedDef();
        }
    }

    private void ClosedDef()
    {
        _sliderDef.gameObject.SetActive(false);
        _sliderDef.value = 0;
    }

    public void ClosedPoison()
    {
        _poison.SetActive(false);
    }

    public void ActiveDef()
    {
        _sliderDef.value = _maxDef;
        _textDef.text = "" + _maxDef;
        _sliderDef.gameObject.SetActive(true);
        DefActive = true;
    }

    void ActiveHp()
    {
        _sliderHP.value = _maxHP;
        _textHP.text = "" + _maxHP;
    }

    public void Hilth()
    {
        var hp = ++_sliderHP.value;
        if (hp > _maxHP)
        {
            _sliderHP.maxValue = hp;
            _sliderHP.value++;
        }
        _textHP.text = "" + _sliderHP.value;
    }

    public void Damage(float damage = 3)
    {
        if (_sliderDef.gameObject.activeSelf)
        {
            _sliderDef.value -= damage;
            _textDef.text = "" + _sliderDef.value;
            if (_sliderDef.value == 0)
            {
                ClosedDef();
            }
        }
        else
        {
            _sliderHP.value -= damage;
            _textHP.text = "" + _sliderHP.value;
            if (_sliderHP.value == 0)
            {
                gameObject.SetActive(false);
                GameSistem.instance.EndGames();
            }
        }
    }

    public void Poison()
    {
        PoisonClose = true;
        _poison.SetActive(true);
        Damage(1);
    }
}
