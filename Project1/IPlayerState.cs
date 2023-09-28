
using Project1;

public interface IPlayerState
	{
		void ChangeDirection(PlayerDirection direction);
		void TakeDamage(int damageAmount);
		void UseWeapon();
		void Update();
		void VictoryState();
		void DeathState();

	}

