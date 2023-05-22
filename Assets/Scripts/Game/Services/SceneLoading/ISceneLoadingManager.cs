namespace Game.Services.SceneLoading
{
    public interface ISceneLoadingManager
    {
        void LoadGameFromSplash();

        float GetProgress();
    }
}