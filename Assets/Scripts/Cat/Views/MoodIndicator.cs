using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Cat.Views
{
    public class MoodIndicator : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        private IDisposable _subscription;
        
        private void Start()
        {
            _subscription = CatManager.Instance.Model.Mood.Subscribe(OnMoodChange);
        }

        private void OnDestroy()
        {
            _subscription.Dispose();
        }

        private void OnMoodChange(int mood)
        {
            _image.fillAmount = (float) (mood + 1) / CatManager.Instance.Model.MaxMood;
            _image.color = CatManager.Instance.CatMoodColor;
        }
    }
}