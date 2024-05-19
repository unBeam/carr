using UnityEngine;

public interface ICarConfig
{
    string Name { get; }
    float Speed { get; }
    float Damage { get; }
    GameObject Prefab { get; }
}