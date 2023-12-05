
namespace Project1
{
    public interface ITime
    {
        public void UpdateElaspedMilli();

        public void UpdateElaspedSec();

        public void ResetElaspedMilli();

        public void ResetElaspedSec();
        public bool CheckIfAttackTimeRandom();
        public bool CheckAnimationFrameTime();

        public bool CheckRandMovementTimeBat();
        public bool CheckRandMovementTime();
        public void SetRandMovementTimeFrame();

        public void UpdateElapsedMoveTime();
        public bool CheckIfAttackTime();
        public void EnableMoveTime();

        public bool PaceTime(int pace);

        public bool CreateAttackAqua();
    }
}
