using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillExplainTxt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txt;

    [SerializeField] private bool _isInfnity;

    [SerializeField] private List<string> _explainTxt;


    private int currentIdx;
    private void Awake()
    {
        _txt.text = _explainTxt[0];

        _txt = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void NextExplainTxt()
    {
        if (currentIdx >= 2)
            return;
        currentIdx++;
        _txt.text = _explainTxt[currentIdx];
    }
}
