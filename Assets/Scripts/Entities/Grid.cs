
public class Grid
{// Двумерная сетка представляет из себя квадрат из бинарных ячеек (Ячейка может быть активна , тогда ее значение True и не активна False. По умолчанию все ячейки True).
 // Представлена в виде двумернрого списка (квадратной матрицы)

    private GridCell[,] _grid;
    private int _side;
    public Grid(int side)
    {
        _side = side;
        _grid = new GridCell[side, side];

        for (int y = 0; y < side; y++)
        {
            for (int x = 0; x < side; x++)
            {
                _grid[y, x] = new GridCell(this, x, y);
            }
        }

    }

    public int setCell(int x, int y)
    {//возвращает 1 при возникновении ощибки связанной с размерностью
        if (x > _side || y > _side || x < 0 || y < 0)
        {
            return 1;
        }

        _grid[y, x].setActive();

        return 0;
    }

    public int checkTheIntegrity()
    {// проверяет на сколько "осколков" распадается сетка и возвращает их количество
        int quality = 0;

        for (int y = 0; y < _side; y++)
        {
            for (int x = 0; x < _side; x++)
            {
                if (_grid[y, x].isActive)
                {
                    if (!_grid[y, x].verified)
                    {
                        quality++;
                        _grid[y, x].check();
                    }
                }
            }
        }

        for (int y = 0; y < _side; y++)
        {
            for (int x = 0; x < _side; x++)
            {
                _grid[y, x].verified = false;
            }
        }

        return quality;
    }

    public GridCell? getCell(int x, int y)
    {
        if ((x > _side - 1) || (y > _side - 1) || (x < 0) || (y < 0)) { return null; }
        return _grid[y, x];
    }

    public class GridCell
    {
        private readonly Grid _grid;
        private readonly int _x;
        private readonly int _y;

        private bool _active = true;

        public bool verified = false;
        public GridCell(Grid grid, int x, int y)
        {
            _grid = grid;
            _x = x;
            _y = y;
        }

        public void setActive()
        {
            if (_active) _active = false;
            else _active = true;
        }

        public void check()
        {
            verified = true;
            GridCell c1 = _grid.getCell(_x - 1, _y),c2 = _grid.getCell(_x + 1, _y), c3 = _grid.getCell(_x, _y + 1), c4 = _grid.getCell(_x, _y - 1);

            if (c1 != null)
            {
                if((c1.isActive) && (!c1.verified))
                {
                    c1.check();
                }

            }
            if (c2 != null)
            {
                if((c2.isActive) && (!c2.verified) )
                {
                    c2.check();
                }
                
            }
            if (c3 != null)
            {
                if ((c3.isActive) && (!c3.verified))
                {
                    c3.check();
                }

            }
            if (c4 != null)
            {
                if((c4.isActive) && (!c4.verified))
                {
                    c4.check();
                }
            }
        }

        public bool isActive { get => _active; }
    }
}
