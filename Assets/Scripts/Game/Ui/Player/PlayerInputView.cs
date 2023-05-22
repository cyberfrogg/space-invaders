using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ui.Player
{
    public class PlayerInputView : UiView
    {
        public Button MoveLeft;
        public Button MoveRight;
        public Button MoveUp;
        public Button MoveDown;
        [Space] 
        public Button Shoot;
    }
}