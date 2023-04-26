using System;
using UniRx;
using UnityEngine;

namespace Cat.Views
{
    public class MoodChangeView : MonoBehaviour
    {
        [SerializeField]
        private Transform _particleSystem;

        [SerializeField]
        private float _speed = 1f;

        [SerializeField]
        private float _liveTime = 5f;
        
        private IDisposable _subscription;
        private bool _isAnimating;
        private float _timer;

        private void Start()
        {
            _subscription = CatManager.Instance.Model.Mood.Pairwise().Subscribe(OnMoodChange);
            _particleSystem.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _subscription.Dispose();
        }

        private void Update()
        {
            if (!_isAnimating)
            {
                return;
            }
            
            var pos = _particleSystem.localPosition;
            _particleSystem.localPosition = new Vector3(pos.x - Time.deltaTime * _speed, pos.y, pos.z);

            _timer += Time.deltaTime;
            if (_timer >= _liveTime)
            {
                _isAnimating = false;
                _particleSystem.gameObject.SetActive(false);
                _timer = 0;
            }
        }
        
        private void OnMoodChange(Pair<int> moodPair)
        {
            if (moodPair.Current <= moodPair.Previous)
            {
                _particleSystem.gameObject.SetActive(false);
                _isAnimating = false;
                return;
            }

            _particleSystem.gameObject.SetActive(true);
            _particleSystem.localPosition = Vector3.zero;
            _isAnimating = true;
            _timer = 0;
        }
    }
}