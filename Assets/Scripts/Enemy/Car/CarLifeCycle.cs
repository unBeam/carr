using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

public class CarLifeCycle : MonoBehaviour
{
    [SerializeField] private float _timeToSpawnCar;
    
    private CompositeDisposable _compositeDisposable = new();
    private EnemySpawner _enemySpawner;
    
    [Inject]
    private void Construct(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
        SubscribeSpawn();
    }

    private void SubscribeSpawn()
    {
        Observable
            .Interval(TimeSpan.FromSeconds(_timeToSpawnCar))
            .Subscribe(_ => SpawnEnemy())
            .AddTo(_compositeDisposable);
    }

    private void SpawnEnemy()
    {
        _enemySpawner.CreateCar();
    }
}
