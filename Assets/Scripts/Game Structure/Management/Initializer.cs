using System;
using TMPro;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] GameObject _cell;
    [SerializeField] GameObject _cellArea;

    public static Grid GridInstance;

    const float CellAreaSize = 400.0f;
    const float CellStandartSize = 100.0f;
    float _cellSizeCoeficient;
    float _cellCurrentSize;
    public void CreateGrid(int size)
    {

        GridInstance = new Grid(size);
        _cellCurrentSize = (CellAreaSize / size);
        _cellSizeCoeficient = _cellCurrentSize / CellStandartSize;


        float xIndent = -CellAreaSize/2, yIndent = CellAreaSize/2;
        for(int y = 0; y < size; y++)
        {
            for(int x = 0; x < size; x++)
            {
                GameObject cell = Instantiate(_cell);
                cell.transform.SetParent(_cellArea.transform, false);
                cell.transform.localScale = new Vector3(_cellSizeCoeficient, _cellSizeCoeficient, _cellSizeCoeficient);
                cell.GetComponent<CellObject>().SetGridPosition(x, y);
                cell.transform.localPosition = new Vector3(xIndent, yIndent, 0);
                xIndent += _cellCurrentSize;
            }
            xIndent = -CellAreaSize/2;
            yIndent -= _cellCurrentSize;        
        }
    }
}
