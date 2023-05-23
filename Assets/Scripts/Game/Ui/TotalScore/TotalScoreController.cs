using PdUtils.Interfaces;
using SimpleUi.Abstracts;

namespace Game.Ui.TotalScore
{
    public class TotalScoreController : UiController<TotalScoreView>, IUiInitializable
    {
        private readonly GameContext _game;

        public TotalScoreController(
            GameContext game
            )
        {
            _game = game;
        }

        public void Initialize()
        {
            View.Link(_game.TotalScoreEntity, _game);
        }
    }
}