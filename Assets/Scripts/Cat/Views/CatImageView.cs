using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Cat.Views
{
    public class CatImageView : MonoBehaviour
    {
        private Image _image;
        
        private IDisposable _subscription;
        
        private void Awake()
        {
            DestroyImg();
        }

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
            DestroyImg();
            var imagePrefab = CatManager.Instance.CatImagePrefab;
            Instantiate(imagePrefab, transform);
        }

        private void DestroyImg()
        {
            _image = GetComponentInChildren<Image>();
            Destroy(_image.gameObject);
        }
    }
}