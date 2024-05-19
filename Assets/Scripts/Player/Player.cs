using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Player : MonoBehaviour, IControllable, IHealth
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private float _speed;
    [SerializeField] private float _hp;

    public Action EndGame;

    private void Start()
    {
        _hpText.text = _hp.ToString();
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime * _speed);
    }

    public void TakeDamage(float _damage)
    {
        _hp -= _damage;
        _hpText.text = _hp.ToString();
        
        if(_hp <= 0)
            EndGame?.Invoke();
    }
}
