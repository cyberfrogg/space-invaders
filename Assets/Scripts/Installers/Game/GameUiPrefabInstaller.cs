using Game.Ui.Player;
using SimpleUi;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameUiPrefabInstaller), fileName = nameof(GameUiPrefabInstaller))]
    public class GameUiPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;

        [SerializeField] private PlayerInputView playerInputView;

        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasView.transform;
            
            var camera = canvasTransform.GetComponentInChildren<Camera>();
            
            Container.BindUiView<PlayerInputController, PlayerInputView>(playerInputView, canvasTransform);
        }
    }
}