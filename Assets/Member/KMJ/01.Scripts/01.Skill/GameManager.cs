using System;
using Member.KMJ._01.Scripts;
using TMPro;
using UnityEngine;

public class GameManager : Monosingleton<GameManager>
{
    public int killCnt;
    [field: SerializeField] public int _maxkillCnt { get; private set; }
    
    [field: SerializeField] public int modifilerKillValue { get; set; }
    public int level { get; set; } = 1;

    [field: SerializeField] public float waitingTime { get; set; }
    [SerializeField] private float _endwaitingTime { get; set; }
    
    public int _currentwave { get; private set; } = 1;
    
    public int _nextWaveCnt { get; private set; } = 3;

    public bool _isWaiting;

    public int coin ;
    
    [SerializeField] private TextMeshProUGUI _WaveTxt;
    [SerializeField] private TextMeshProUGUI _killTxt;

    public bool isEnd { get; private set; } = false;

    protected override void Awake()
    {
        _killTxt.text = $"KillCount : {killCnt}";
        _WaveTxt.text = $"Level : {level}";
        base.Awake();
    }

    public void AddKillCount(int KillCnt)
    {
        killCnt += KillCnt;

        _killTxt.text = $"KillCount : {killCnt}";
        
        if (killCnt >= _maxkillCnt)
        {
            _currentwave += 1;
            _maxkillCnt += modifilerKillValue;
            ShowPanel();
        }
    }
    
    private void ShowPanel()
    {
        if (_currentwave >= _nextWaveCnt)
        {
            level++;
            _WaveTxt.text = $"Level : {level}";
            CardSystem.instance.Show();

            if (_currentwave >= 30)
            {
                isEnd = true;
            }
        }
        else
            return;
    }
}
