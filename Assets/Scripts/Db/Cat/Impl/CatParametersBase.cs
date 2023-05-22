using UnityEngine;

namespace Db.Cat.Impl
{
    [CreateAssetMenu(menuName = "Settings/Cat/" + nameof(CatParametersBase), fileName = nameof(CatParametersBase))]
    public class CatParametersBase : ScriptableObject, ICatParametersBase
    {
        [SerializeField] private float _angryMoodValue;
        [SerializeField] private float _neutralMoodValue;
        [SerializeField] private float _happyMoodValue;
        [Header("Preview")] 
        [SerializeField] private Gradient _previewGradient;

        public float AngryMoodValue => _angryMoodValue;
        public float NeutralMoodValue => _neutralMoodValue;
        public float HappyMoodValue => _happyMoodValue;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            _previewGradient = new Gradient();
            var keys = new[]
            {
                new GradientColorKey(Color.red, _angryMoodValue),
                new GradientColorKey(Color.yellow, _neutralMoodValue),
                new GradientColorKey(Color.green, _happyMoodValue),
            };
            var emptyAlphaKeys = new[]
            {
                new GradientAlphaKey(1, _angryMoodValue),
            };

            _previewGradient.mode = GradientMode.Fixed;
            _previewGradient.SetKeys(keys, emptyAlphaKeys);
        }
#endif
    }
}