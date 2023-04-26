using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace Cat.Views
{
    [RequireComponent(typeof(TMP_Text))]
    public class ReactionTextView : MonoBehaviour
    {
        private TMP_Text _textField;

        private IDisposable _subscription;

        private void Awake()
        {
            _textField = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _subscription = CatManager.Instance.Model.Reaction.Subscribe(OnReactionChange);
        }

        private void OnDestroy()
        {
            _subscription.Dispose();
        }

        private void OnReactionChange(string reactionString)
        {
            _textField.text = reactionString;
        }
    }
}