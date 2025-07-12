using System;
using Member.KMJ._01.Scripts;
using UnityEngine;

public class GameManager : Monosingleton<GameManager>
{
    public int killCnt;
    [field: SerializeField] public int _maxkillCnt { get; private set; }
    
    [field: SerializeField] public int modifilerKillValue { get; set; }
    public int level{ get; set; }

    public int _currentwave { get; private set; } = 1;
    public int _nextWaveCnt { get; private set; } = 3;
    

    public bool isEnd { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    public void AddKillCount(int KillCnt)
    {
        killCnt += KillCnt;

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
            CardSystem.instance.Show();
        }
        else
            return;
    }
}
