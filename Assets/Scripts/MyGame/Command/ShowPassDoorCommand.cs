using QFramework;

namespace BallRollGame
{
    public class ShowPassDoorCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<ShowPassDoorEvent>();
        }
    }
}
