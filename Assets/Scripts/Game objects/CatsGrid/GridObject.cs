using System;
using TMPro;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _numberOfFragments;
    private void OnEnable()
    {
        CellObject.SetActive += SetActive;
    }

    private void SetActive(int x, int y)
    {
        Initializer.GridInstance.setCell(x, y);
        SetFragmentQuality();
    }

    public void SetFragmentQuality()
    {
        _numberOfFragments.text = Convert.ToString(Initializer.GridInstance.checkTheIntegrity());
    }

    private void OnDisable()
    {
        CellObject.SetActive -= SetActive;
    }
}
