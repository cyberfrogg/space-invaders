using JCMG.EntitasRedux;
using PdUtils.Interfaces;
using SimpleUi.Abstracts;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Ui.Player
{
    public class PlayerInputController : UiController<PlayerInputView>, IUiInitializable, IUpdateSystem
    {
        private readonly ActionContext _action;

        private Vector2 _previousDirection;

        public PlayerInputController(
            ActionContext action
            )
        {
            _action = action;
        }

        public void Initialize()
        {
            View.MoveDown.OnPointerDownAsObservable().Subscribe(_ => { OnMove(Vector2.down); }).AddTo(View);
            View.MoveDown.OnPointerUpAsObservable().Subscribe(_ => { OnMove(Vector2.zero); }).AddTo(View);
            
            View.MoveUp.OnPointerDownAsObservable().Subscribe(_ => { OnMove(Vector2.up); }).AddTo(View);
            View.MoveUp.OnPointerUpAsObservable().Subscribe(_ => { OnMove(Vector2.zero); }).AddTo(View);
            
            View.MoveLeft.OnPointerDownAsObservable().Subscribe(_ => { OnMove(Vector2.left); }).AddTo(View);
            View.MoveLeft.OnPointerUpAsObservable().Subscribe(_ => { OnMove(Vector2.zero); }).AddTo(View);
            
            View.MoveRight.OnPointerDownAsObservable().Subscribe(_ => { OnMove(Vector2.right); }).AddTo(View);
            View.MoveRight.OnPointerUpAsObservable().Subscribe(_ => { OnMove(Vector2.zero); }).AddTo(View);
        }

        public void Update()
        {
            _action.CreateEntity().AddMove(_previousDirection);
        }
        
        private void OnMove(Vector2 direction)
        {
            _previousDirection = direction;
        }
    }
}