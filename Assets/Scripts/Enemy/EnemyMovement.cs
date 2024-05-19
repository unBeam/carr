using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemyMovement
{
    private const float LifeTime = 10f;
    
    private CompositeDisposable _compositeDisposable = new();

    private Enemy _car;
    private bool _canMove = true;
    private float _speed;
    private Transform[] _movementPoint;

    public EnemyMovement(Transform[] movementPoint)
    {
        _movementPoint = movementPoint;
    }

    public async void TakeSpeed(float speed, Enemy car)
    {
        _speed = speed;
        _car = car;
        _car.transform.position = _movementPoint[Random.Range(0, _movementPoint.Length)].position;
        SubcribeMovement();
        await ReturnCar();
    }

    private void SubcribeMovement()
    {
        _compositeDisposable.Clear();
        
        Observable
            .EveryUpdate()
            .Where(_ => _canMove == true)
            .Subscribe(_ => Movement())
            .AddTo(_compositeDisposable);
    }
    
    private void Movement()
    {
        _car.transform.Translate(new Vector3(0f,- _speed * Time.deltaTime,0f));
    }

    private async UniTask ReturnCar()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(LifeTime));
        _car.gameObject.SetActive(false);
    }

}
