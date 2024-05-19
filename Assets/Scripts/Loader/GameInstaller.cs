using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private BaseCar[] _carConfigs;
    [SerializeField] private Transform[] _movementPoints;

    public override void InstallBindings()
    {
        BindPool();
        BindInterfaces();
        BindEnemyScripts();
    }

    private void BindPool()
    {
        Container
            .BindInterfacesAndSelfTo<PoolObject<Enemy>>()
            .AsSingle()
            .OnInstantiated<PoolObject<Enemy>>((context, pool) =>
            {
                AddCarInPool(pool);
            })
            .NonLazy();
    }

    private void BindInterfaces()
    {
        Container.Bind<ICarFactory>().To<EnemyFactory>().AsTransient();
        Container.Bind<IControllable>().To<Player>().FromComponentInHierarchy().AsSingle();
    }

    private void BindEnemyScripts()
    {
        Container
            .BindInterfacesAndSelfTo<EnemySpawner>()
            .AsSingle()
            .NonLazy();

        Container.Bind<BaseCar[]>().FromInstance(_carConfigs).AsSingle();
        Container.Bind<Transform[]>().FromInstance(_movementPoints).AsSingle();
        Container.Bind<EnemyMovement>().AsSingle();
    }
    private void AddCarInPool(PoolObject<Enemy> pool)
    {
        foreach (var config in _carConfigs)
        {
            pool.AddElementsInPool(config.Name,config.Prefab,5);
        }
    }
}
