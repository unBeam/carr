using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    private CompositeDisposable _compositeDisposable = new();
    private float _time;
    public float Time => _time;

    private void Start()
    {
        SubscribeTimer();
    }
    
    private void SubscribeTimer()
    {
        Observable
            .Interval(TimeSpan.FromSeconds(1))
            .Subscribe(_ => TimerUpdate())
            .AddTo(_compositeDisposable);
    }
    
    private void TimerUpdate()
    {
        _time += 1;
        _timer.text = _time.ToString();
    }
}
