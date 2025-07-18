using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FactoryAuto : MonoBehaviour 
{
    public Auto[] prefAutos;

    public Auto CreateAuto(ParametrAuto parametr)
    {
        Auto auto = Instantiate(prefAutos[parametr.width - 1]);
        auto.parametr = parametr;

        if(auto.parametr.direction == Vector2Int.right)
        {
            auto.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        if (auto.parametr.direction == Vector2Int.down)
        {
            auto.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (auto.parametr.direction == Vector2Int.left)
        {
            auto.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        return auto;
    }

    public List<Auto> CreateAutos(List<ParametrAuto> paratrs)
    {
        List<Auto> autos = new List<Auto>();

        foreach (var auto in paratrs) 
        {
            autos.Add(CreateAuto(auto));
        }

        return autos;
    }
}
