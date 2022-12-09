using System;
using UnityEngine;

public class BoosterSing : MonoBehaviour
{
    public static BoosterSing instance;

    private void Start()
    {
        instance = this;
    }
    
    public void Boost(string tag,GameObject gameObject)
    {
        var dateObj = gameObject.GetComponent<DateObject>();
        switch (tag)
        {
            case "Attack":
                dateObj.Damage();
                break;
            
            case "Hilth":
                dateObj.Hilth();
                break;
            
            case "Poison":
                dateObj.Poison();
                break;
            
            case "Def":
                dateObj.ActiveDef();
                break;
        }
    }
}
