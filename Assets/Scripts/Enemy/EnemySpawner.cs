using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class EnemySpawner
{
    private ICarFactory _carFactory;
    private BaseCar[] _baseCarConfig;
    
    public EnemySpawner(ICarFactory carFactory,BaseCar[] baseCarConfig)
    {
        _carFactory = carFactory;
        _baseCarConfig = baseCarConfig;
    }

    public void CreateCar()
    {
        _carFactory.CreateCar(_baseCarConfig[Random.Range(0,_baseCarConfig.Length)]);
    }
}
