public class EnemyFactory : ICarFactory
{
    private PoolObject<Enemy> _pool;
    private EnemyMovement _enemyMovement;

    public EnemyFactory(PoolObject<Enemy> pool, EnemyMovement enemyMovement)
    {
        _pool = pool;
        _enemyMovement = enemyMovement;
    }

    public void CreateCar(ICarConfig carConfig)
    {
        Enemy car = _pool.GetElementInPool(carConfig.Name);
        car.SetDamage(carConfig.Damage);
        _enemyMovement.TakeSpeed(carConfig.Speed,car);
    }
}
