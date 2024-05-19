using UnityEngine;

[CreateAssetMenu(fileName = "BaseCar", menuName = "Scriptable Objects/BaseCar")]
public class BaseCar : ScriptableObject, ICarConfig
{
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public GameObject Prefab { get; protected set; }
    [field: SerializeField] public float Speed { get; protected set; }
    [field: SerializeField] public float Damage { get; protected set; }
}
