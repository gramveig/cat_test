using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Cat
{
    public class CatManager : MonoBehaviour
    {
        [SerializeField]
        private List<CatMood> _moodSeq;

        [SerializeField]
        private CatMood _startMood;

        public CatModel Model;

        private CatMood _curMood;
        private static CatManager _instance;

        private void Awake()
        {
            _instance = this;
            
            _curMood = _startMood;
            foreach (var mood in _moodSeq)
            {
                mood.Init(this);
            }

            Model = new CatModel(_moodSeq.IndexOf(_curMood), _moodSeq.Count);
        }

        public static CatManager Instance => _instance;

        public void Play()
        {
            _curMood.Play();
        }

        public void Feed()
        {
            _curMood.Feed();
        }

        public void Pet()
        {
            _curMood.Pet();
        }

        public void Kick()
        {
            _curMood.Kick();
        }

        public void ChangeMood(CatMoodChange moodChange)
        {
            switch (moodChange)
            {
                case CatMoodChange.None: break;
                case CatMoodChange.ToWorst: ChangeMoodToWorst();
                    break;
                case CatMoodChange.ToWorse: ChangeMoodToWorse();
                    break;
                case CatMoodChange.ToBetter: ChangeMoodToBetter();
                    break;
                case CatMoodChange.ToBest: ChangeMoodToBest();
                    break;
                default: throw new Exception("Unknown mood change");
            }
        }

        public void SetReaction(CatReaction reaction)
        {
            Model.Reaction.Value = reaction.ReactionString;
            Debug.Log("Set reaction: " + Model.Reaction.Value);
        }

        public GameObject CatImagePrefab => _curMood.ImagePrefab;

        public Color CatMoodColor => _curMood.Color;

        private void ChangeMoodToWorst()
        {
            _curMood = _moodSeq[0];
            Model.Mood.Value = 0;
            Debug.Log("Set mood to " + 0);
        }

        private void ChangeMoodToWorse()
        {
            int curMoodIdx = _moodSeq.IndexOf(_curMood);
            if (curMoodIdx == 0)
            {
                return;
            }

            int newMoodIdx = curMoodIdx - 1;
            _curMood = _moodSeq[newMoodIdx];
            Model.Mood.Value = newMoodIdx;
            Debug.Log("Set mood to " + newMoodIdx);
        }
        
        private void ChangeMoodToBetter()
        {
            int curMoodIdx = _moodSeq.IndexOf(_curMood);
            if (curMoodIdx > _moodSeq.Count - 2)
            {
                return;
            }

            int newMoodIdx = curMoodIdx + 1;
            _curMood = _moodSeq[newMoodIdx];
            Model.Mood.Value = newMoodIdx;
            Debug.Log("Set mood to " + newMoodIdx);
        }

        private void ChangeMoodToBest()
        {
            int newMoodIdx = _moodSeq.Count - 1;
            _curMood = _moodSeq[newMoodIdx];
            Model.Mood.Value = newMoodIdx;
            Debug.Log("Set mood to " + newMoodIdx);
        }
    }
}