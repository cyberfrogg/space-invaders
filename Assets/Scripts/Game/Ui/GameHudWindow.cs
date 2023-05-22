using Game.Ui.Player;
using SimpleUi;

namespace Game.Ui
{
    public class GameHudWindow : WindowBase
    {
        public override string Name => "GameHud";

        protected override void AddControllers()
        {
            AddController<PlayerInputController>();
        }
    }
}