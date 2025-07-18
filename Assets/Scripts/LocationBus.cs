using System.Collections.Generic;
using UnityEngine;

public class LocationBus : MonoBehaviour
{
    public int width;
    public int height;

    public List<ParametrAuto> autos;
    public SetList<Vector2Int> freePosition;

    private Grid grid;
    private FactoryAuto factory;

    private List<Auto> autosCreate;

    private void Start()
    {
        factory = GetComponent<FactoryAuto>();
        grid = new Grid(width, height);
        autos = new List<ParametrAuto>();
        freePosition = new SetList<Vector2Int>();

        freePosition.Add(new Vector2Int(width/2,height/2));

        RandomPlace();

        autosCreate = factory.CreateAutos(autos);

        foreach (Auto auto in autosCreate)
        {
            auto.transform.position = new Vector2(auto.parametr.position.x - 5, auto.parametr.position.y - 4.5f);
        }
    }

    public void RandomPlace()
    {
        for(int i = 0; i < 100; i++)
        {
            for (int g = 0; g < 20; g++)
            {
                ParametrAuto parametr = RandomAutoGeneration();
                if (!grid.AddAuto(parametr))
                {
                    continue;
                }

                freePosition.Remove(parametr.position);

                autos.Add(parametr);
                for(int x = 0; x < width; x++)
                {
                    for(int y = 0; y < height; y++)
                    {
                        if (grid[x,y] != Grid.EMPTY)
                        {
                            continue;
                        }
                        Vector2Int up = new Vector2Int(Mathf.Clamp( x - 1, 0, width -1), y);
                        Vector2Int upRight = new Vector2Int(Mathf.Clamp(x - 1, 0, width -1), Mathf.Clamp(y + 1, 0, height -1));
                        Vector2Int right = new Vector2Int(x, Mathf.Clamp(y + 1, 0, height-1));
                        Vector2Int downRight = new Vector2Int(Mathf.Clamp(x + 1, 0, width-1), Mathf.Clamp(y + 1, 0, height-1));
                        Vector2Int down = new Vector2Int(Mathf.Clamp(x + 1, 0, width-1), y);
                        Vector2Int downLeft = new Vector2Int(Mathf.Clamp(x + 1, 0, width-1), Mathf.Clamp(y - 1, 0, height-1));
                        Vector2Int left = new Vector2Int(x, Mathf.Clamp(y - 1, 0, height - 1));
                        Vector2Int upLeft = new Vector2Int(Mathf.Clamp(x - 1, 0, width - 1), Mathf.Clamp(y - 1, 0, height - 1));

                        if (grid[up.x, up.y] == Grid.BUSY
                            || grid[upRight.x, upRight.y] == Grid.BUSY 
                            || grid[right.x, right.y] == Grid.BUSY 
                            || grid[downRight.x, downRight.y] == Grid.BUSY 
                            || grid[down.x, down.y] == Grid.BUSY 
                            || grid[downLeft.x, downLeft.y] == Grid.BUSY
                            || grid[left.x, left.y] == Grid.BUSY 
                            || grid[upLeft.x, upLeft.y] == Grid.BUSY)
                        {
                            freePosition.Add(new Vector2Int(x, y));
                        }
                    }
                }
                break;
            }
        }
    }

    public ParametrAuto RandomAutoGeneration()
    {
        ParametrAuto parametr = new ParametrAuto();

        parametr.position = freePosition[UnityEngine.Random.Range(0, freePosition.Count())];
        parametr.color = RandomColor();

        parametr.direction = RandomDirection();
        parametr.width = UnityEngine.Random.Range(1, 5);

        return parametr;
    }

    public Vector2Int RandomDirection()
    {
        return ParametrAuto.directions[UnityEngine.Random.Range(0, ParametrAuto.directions.Length)];
    }

    public Color RandomColor()
    {
        return ParametrAuto.colors[UnityEngine.Random.Range(0, ParametrAuto.colors.Length)];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            for(int i = autosCreate.Count-1; i> -1; i--)
            {
                Destroy(autosCreate[i].gameObject);
            }

            Start();
        }
    }
}
