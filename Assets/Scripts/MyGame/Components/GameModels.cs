using QFramework;

namespace BallRollGame

{
    public interface IGameModel : IModel
    {
        BindableProperty<int> Score { get; }
    }

    public class GameModels : AbstractModel, IGameModel
    {
        BindableProperty<int> IGameModel.Score { get; } = new BindableProperty<int>(0);

        protected override void OnInit()
        {
            
        }
    }
}
