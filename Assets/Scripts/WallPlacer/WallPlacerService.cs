using System;
using UnityEngine;

public class WallPlacerService : MonoBehaviour
{
    [SerializeField] private Transform _topWall;
    [SerializeField] private Transform _downWall;
    [SerializeField] private Transform _leftWall;
    [SerializeField] private Transform _rightWall;

    private Camera _camera;
    private float _leftX;
    private float _rightX;
    private float _topY;
    private float _downY;

    private void Start()
    {
        _camera = Camera.main;
        CalculateScreenCornersInWorldCoordinates();
        MoveWallsToScreenBorder();
    }

    private void MoveWallsToScreenBorder()
    {
        
        _topWall.position = new Vector2(0, _topY +  transform.localScale.y/2);
        _downWall.position = new Vector2(0, _downY); // не делаю сдвиг чтобы мячик отбивался от земли а не от края экрана 

        _leftWall.position = new Vector2(_leftX - transform.localScale.x/2, 0);
        _rightWall.position = new Vector2(_rightX + transform.localScale.x/2, 0);
    }

    private void CalculateScreenCornersInWorldCoordinates()
    {
        Vector3 leftTopCorner = _camera.ScreenToWorldPoint(new Vector3(0, _camera.pixelHeight, _camera.nearClipPlane));
        Vector3 rightDownCorner = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, 0, _camera.nearClipPlane));

        _leftX = leftTopCorner.x;
        _rightX = rightDownCorner.x;
        _topY = leftTopCorner.y;
        _downY = rightDownCorner.y;
    }
}