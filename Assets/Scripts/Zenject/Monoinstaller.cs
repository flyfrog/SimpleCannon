using UnityEngine;
using Zenject;

public class Monoinstaller : MonoInstaller
{
     [SerializeField] private CannonFireSettingsSO _cannonFireSettingsSO;
     [SerializeField] private FXSettingsSO _FXSettingsSO;
     [SerializeField] private GameSettingsSO _gameSettingsSO;

    public override void InstallBindings()
    {
        //Scriptable object
        Container.Bind<CannonFireSettingsSO>().FromInstance(_cannonFireSettingsSO).AsSingle().NonLazy();
        Container.Bind<FXSettingsSO>().FromInstance(_FXSettingsSO).AsSingle().NonLazy();
        Container.Bind<GameSettingsSO>().FromInstance(_gameSettingsSO).AsSingle().NonLazy();


        //Normal class
        Container.Bind<CannonShotController>().AsSingle().NonLazy();
        Container.Bind<TargetDamageController>().AsSingle().NonLazy();
        Container.Bind<BulletDeathService>().AsSingle().NonLazy();
        Container.Bind<TargetDeathService>().AsSingle().NonLazy();
        Container.Bind<CanonFireFXController>().AsSingle().NonLazy();
        Container.Bind<BulletExplosionFXController>().AsSingle().NonLazy();
        Container.Bind<TargetExplosionFXController>().AsSingle().NonLazy();
        // -- 
        Container.Bind<PauseManager>().AsSingle().NonLazy();
        Container.Bind<StartGameManager>().AsSingle().NonLazy();
        Container.Bind<UIMenuController>().AsSingle().NonLazy();
        Container.Bind<RestartManager>().AsSingle().NonLazy();
        Container.Bind<ExitManager>().AsSingle().NonLazy();
        Container.Bind<WinManager>().AsSingle().NonLazy();
        Container.Bind<GameOverManager>().AsSingle().NonLazy();

        
        //intarface realize
       // Container.BindInterfacesAndSelfTo<PlayerMoveController>().AsSingle().NonLazy();
       Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();
       Container.BindInterfacesAndSelfTo<CannonRotationController>().AsSingle().NonLazy();
       Container.BindInterfacesAndSelfTo<CannonReloadingService>().AsSingle().NonLazy();
       Container.BindInterfacesAndSelfTo<TimerController>().AsSingle().NonLazy();
       Container.BindInterfacesAndSelfTo<InitGameManager>().AsSingle().NonLazy();
       
        
    }
}