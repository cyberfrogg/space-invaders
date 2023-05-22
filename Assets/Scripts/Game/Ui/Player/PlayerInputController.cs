using JCMG.EntitasRedux;
using PdUtils.Interfaces;
using SimpleUi.Abstracts;
using UnityEngine;

namespace Game.Ui.Player
{
    public class PlayerInputController : UiController<PlayerInputView>, IUiInitializable, IUpdateSystem
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;

        public PlayerInputController(
            ActionContext action,
            GameContext game
            )
        {
            _action = action;
            _game = game;
        }

        public void Initialize()
        {

        }

        public void Update()
        {
            var dirToMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _action.CreateEntity().AddMovePlayer(dirToMove);

            if (Input.GetButtonDown("Fire1"))
            {
                _action.CreateEntity().AddShoot(_game.PlayerEntity.Uid.Value);
            }
        }
    }
}