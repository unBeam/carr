using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _damage;
    
    public void SetDamage(float damage)
    {
        _damage = damage;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IHealth iHealth))
        {
            ApplyDamage(iHealth);
            gameObject.SetActive(false);
        }
    }
    
    private void ApplyDamage(IHealth iHealth)
    {
        iHealth.TakeDamage(_damage);
    }
}