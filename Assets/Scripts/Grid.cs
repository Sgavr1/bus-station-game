public class Grid
{
    public const int EMPTY = 0;
    public const int BUSY = 1;

    public int width;
    public int height;

    private int[,] grid;

    public int this[int x, int y]
    {
        get { return grid[x, y]; }
        set { grid[x, y] = value; }
    }

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;

        grid = new int[width, height];

        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                grid[i, j] = EMPTY;
            }
        }
    }

    public bool AddAuto(ParametrAuto parametr)
    {
        int x = parametr.position.x;
        int y = parametr.position.y;

        if (!CheckBound(parametr) || ChekColision(parametr))
        {
            return false;
        }

        for (int i = 0; i < parametr.width; i++)
        {
            grid[x, y] = BUSY;
            x += parametr.direction.x;
            y += parametr.direction.y;
        }

        return true;
    }

    public bool ChekColision(ParametrAuto parametr)
    {
        int x = parametr.position.x;
        int y = parametr.position.y;

        for(int i = 0; i < parametr.width; i++)
        {
            if (grid[x, y] != EMPTY)
            {
                return true;
            }

            x += parametr.direction.x;
            y += parametr.direction.y;
        }

        return false;
    }

    public bool ChekBoundGrid(int x, int y)
    {
        return x > -1 && x < width && y > -1 && y < height;
    }

    public bool CheckBound(ParametrAuto parametr)
    {
        bool boundX = parametr.position.x > -1;
        boundX &= parametr.position.x < width;
        boundX &= parametr.position.x + parametr.width * parametr.direction.x > -1;
        boundX &= parametr.position.x + parametr.width * parametr.direction.x < width;

        bool boundY = parametr.position.y > -1;
        boundY &= parametr.position.y < height;
        boundY &= parametr.position.y + parametr.width * parametr.direction.y > -1;
        boundY &= parametr.position.y + parametr.width * parametr.direction.y < height;

        return boundX && boundY;
    }
}