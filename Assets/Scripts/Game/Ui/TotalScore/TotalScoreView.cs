using Ecs.Views.Linkable.Impl.Ui;
using TMPro;

namespace Game.Ui.TotalScore
{
    public class TotalScoreView : LinkableUiView<GameEntity>, IAnyTotalScoreAddedListener
    {
        public TextMeshProUGUI Text;
        
        protected override void Listen(GameEntity entity)
        {
            entity.AddAnyTotalScoreAddedListener(this);
        }

        protected override void Unlisten(GameEntity entity)
        {
            entity.RemoveAnyTotalScoreAddedListener(this);
        }

        protected override void Reset()
        {
            
        }

        public void OnAnyTotalScoreAdded(GameEntity entity, int value)
        {
            Text.text = value.ToString("000000");
        }
    }
}