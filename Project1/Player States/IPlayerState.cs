
using Project1;

public interface IPlayerState
	{
		void ChangeDirection(PlayerDirection direction);
        void IsMoving(bool moving);
    //  void TakeDamage(int damageAmount);  implementing in the future
    //   void UseWeapon();                  implementing in the future
    void Update(PlayerDirection direction, bool moving);
    // void VictoryState();                 implementing in the future
    // void DeathState();	                implementing in the future


}

