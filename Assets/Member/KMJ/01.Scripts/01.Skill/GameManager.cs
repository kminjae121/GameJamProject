using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Member.KMJ._01.Scripts;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int killCnt;
    public static GameManager Instance;
    [field: SerializeField] public List<int> _maxkillCnt { get; private set; }
    
    [field: SerializeField] public int modifilerKillValue { get; set; }
    public int level { get; set; } = 1;

    private int currentKillCnt;

    [field: SerializeField] public float waitingTime { get; set; }
    [SerializeField] private float _endwaitingTime { get; set; }

    public event Action<int> OnWaveChangeEvent;


    public int _currentwave { get; private set; } = 1;

    [field: SerializeField] public int coin { get; set; } = 0;
    public int _nextWaveCnt { get; private set; } = 3;

    public bool _isWaiting;
    
    [SerializeField] private TextMeshProUGUI _WaveTxt;
    [SerializeField] private TextMeshProUGUI _killTxt;
    [SerializeField] private TextMeshProUGUI _coinTxt;
    

    public bool isEnd { get; private set; } = false;

    protected void Awake()
    {
        Instance = this;
        _coinTxt.text = $"코인 : {this.coin}";
        _killTxt.text = $"남은 적 : {_maxkillCnt[currentKillCnt]}";
        _WaveTxt.text = $"레벨 : {level}";
    }

    private void Start()
    {
        FadeUI.Instance.FindTxt("StageTxt").gameObject.SetActive(true);
        FadeUI.Instance.FindTxt("StageTxt").alpha = 255f;
            
        FadeUI.Instance.FindTxt("StageTxt").text = $"Wave{_currentwave}";
        FadeUI.Instance.FadeTxt(0, 3, "StageTxt");
    }

    public void AddKillCount(int KillCnt)
    {
        if(isEnd == false)
        {
            _maxkillCnt[currentKillCnt] -= KillCnt;
            _killTxt.text = $"남은 적 : {_maxkillCnt[currentKillCnt]}";

        
            if (_maxkillCnt[currentKillCnt] <= 0)
            {
                _currentwave += 1;
                currentKillCnt++;
                
                
                _killTxt.text = $"남은 적 : {_maxkillCnt[currentKillCnt]}";
                FadeUI.Instance.FindTxt("StageTxt").gameObject.SetActive(true);
                FadeUI.Instance.FindTxt("StageTxt").alpha = 255f;
            
                FadeUI.Instance.FindTxt("StageTxt").text = $"Wave{_currentwave}";
                FadeUI.Instance.FadeTxt(0, 3, "StageTxt");
                OnWaveChangeEvent?.Invoke(_currentwave);
                ShowPanel();
                if (_currentwave == 25)
                {
                    isEnd = true;
                }
            
            }
        }
    }


    public void GetCoin(int coin)
    {
        this.coin += coin;
        _coinTxt.text = $"코인 : {this.coin}";
    }

    public void MinusCoin(int coin)
    {
        if (this.coin - coin < 0)
            return;
        
        this.coin -= coin;
        _coinTxt.text = $"코인 : {this.coin}";
    }
    
    private void ShowPanel()
    {
        if (_currentwave >= _nextWaveCnt)
        {
            level++;
            _nextWaveCnt += 3;
            _WaveTxt.text = $"레벨 : {level}";
           
            CardSystem.instance.Show();
        }
        else
            return;
    }
}
