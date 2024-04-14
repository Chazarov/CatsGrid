using System;
using UnityEngine;

public class CellObject: MonoBehaviour 
{
    public delegate void CellSetActiveDelegate(int x, int y);
    public static event CellSetActiveDelegate SetActive;

    int _x;
    int _y;

    [SerializeField] GameObject _activeIcon;
    [SerializeField] GameObject _inactiveIcon;
    bool _active = true;

    

    public void SetGridPosition(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void setActive()
    {
        if(SetActive != null)
        {
            SetActive(_x, _y);
        }

        setView();
    }

    private void setView()
    {
        _activeIcon.SetActive(false);
        _inactiveIcon.SetActive(false);

        if (_active)
        {
            _inactiveIcon.SetActive(true);
            _active = false;
        }
        else
        {
            _activeIcon.SetActive(true);
            _active = true;
        }
    }
}
