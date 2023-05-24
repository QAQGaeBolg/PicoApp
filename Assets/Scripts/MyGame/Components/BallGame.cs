using BallRollGame;
using QFramework;
using UnityEngine;

namespace BallRollGame
{
    public class BallGame : Architecture<BallGame>
    {
        // Start is called before the first frame update
        protected override void Init()
        {
            RegisterModel<IGameModel>(new GameModels());
            RegisterModel<IGameAudioModel>(new GameAudioModel());
            RegisterSystem<ITimerSystem>(new TimerSystem());
            RegisterSystem<ICameraSystem>(new CameraSystem());
            RegisterSystem<IAudioMgrSystem>(new AudioMgrSystem());
            RegisterSystem<IObjectPoolSystem>(new ObjectPoolSystem());
            RegisterSystem<IPlayerInputSystem>(new PlayerInputSystem());
        }
    }

    public class BallGameController: MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return BallGame.Interface;
        }
    }
}

