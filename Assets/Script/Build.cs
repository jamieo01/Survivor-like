using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] Transform _buildPoint;
    [SerializeField] private GameObject _wallPiece;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) 
        {
            
            Instantiate(_wallPiece, _buildPoint);
        
        }
    }
}
