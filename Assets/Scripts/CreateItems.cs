using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CreateItems : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;

    private void OnEnable()
    {
        CreateItem();
    }

    public void CreateItem()
    {
        var id = Random.Range(0, _sprites.Count);
        GetComponent<Image>().sprite = _sprites[id];
        switch (id)
        {
            case 0:
                gameObject.tag = "Attack";
                break;
            
            case 1:
                gameObject.tag = "Hilth";
                break;
            
            case 2:
                gameObject.tag = "Poison";
                break;
            
            case 3:
                gameObject.tag = "Def";
                break;
        }
    }
}
