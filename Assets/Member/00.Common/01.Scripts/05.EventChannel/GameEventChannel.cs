using System;
using System.Collections.Generic;
using UnityEngine;

namespace Blade.Core
{
    public class GameEvent
    {
        
    }
    [CreateAssetMenu(menuName = "SO/EventChannel", fileName = "EventChannel")]
    public class GameEventChannel : ScriptableObject
    {
        private Dictionary<Type,Action<GameEvent>> _events = new Dictionary<Type, Action<GameEvent>>();
        private Dictionary<Delegate,Action<GameEvent>> _lookUp = new Dictionary<Delegate,Action<GameEvent>>();

        public void AddListener<T>(Action<T> handler) where T : GameEvent
        {
            if (_lookUp.ContainsKey(handler) == false)// 이미 구독중인 메서드는 차겆ㄱ으로 구독되지 않도록 막는다
            {
                Action<GameEvent> _castHandler = (evt) => handler(evt as T); //Action<T>을 일반화된 Action<GameEvent>로 변환:
                                                                             //핸들러에 넘겨주는 래핑 함수 생성.


                _lookUp[handler] = _castHandler; //외부에서 전달된 핸들러와 델리게이트를 매핑.
                
                Type evtType = typeof(T);

                if (_events.ContainsKey(evtType)) //_events 딕셔너리에 타입 별로 구독 핸들러 추가
                {
                    _events[evtType] += _castHandler; 
                }
                else
                {
                    _events[evtType] = _castHandler;
                }
            }
        }

        public void RemoveListener<T>(Action<T> handler) where T : GameEvent
        {
            Type evtType = typeof(T); //현재 구독 중인 이벤트 타입을 Type으로 가져옵니다
            if (_lookUp.TryGetValue(handler, out Action<GameEvent> action)) //외부에서 등록한 핸들러가 _lookUp에 존재하는지 확인하고, 내부용 델리게이트(_castHandler)를 얻습니다.
            {
                if (_events.TryGetValue(evtType, out Action<GameEvent> internalAction)) //해당 타입에 대한 이벤트 핸들러가 _events에 등록되어 있는지 확인합니다.
                {
                    internalAction -= action;
                    if (internalAction == null)
                        _events.Remove(evtType);
                    else
                    {
                        _events[evtType] = internalAction; //핸들러가 일부 남아있으면 업데이트
                    }
                }
            }

            _lookUp.Remove(handler);//_lookUp에서도 해당 핸들러 제거
        }
        
        public void RaiseEvent(GameEvent evt)
        {
            if(_events.TryGetValue(evt.GetType(), out Action<GameEvent> handlers)) //evt의 실제 타입에 맞는 핸들러들을 찾습니다
                handlers?.Invoke(evt); //핸들러가 있으면 실행 
        }

        public void Clear()
        {
            _events.Clear();
            _lookUp.Clear();
        }
    }
    
}
