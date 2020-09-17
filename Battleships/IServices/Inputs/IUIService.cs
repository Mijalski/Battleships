using Battleships.Business.Grids;

namespace Battleships.IServices.Inputs
{
    public interface IUIService
    {
        string GetGridSquareIdInput();
        void NotifyAboutGameStart();
        void NotifyAboutShotOnTarget();
        void NotifyAboutShotMissed();
        void NotifyAboutGameFinish();
        void RefreshGrid(Grid grid);
    }
}