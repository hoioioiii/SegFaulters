
using Microsoft.VisualBasic;
using Project1;

public class LeftMovingPlayerState : IPlayerState
{
    private PlayerState playerState;
    //placeholder till connected with global health system
    private int health;
    private Player player;

    public LeftMovingPlayerState(Player player, int initialHealth)
    {
        int xPos = player.positionX; 
        int yPos = player.positionY;
        this.health = initialHealth;
        this.player = player;
        
        //construct sprite here too?? (texture?)
    }

    public void ChangeDirection(PlayerDirection direction)
    {
        //fix other directions' classes
        switch (direction) {
            case PlayerDirection.Left:
                break;
            case PlayerDirection.Right:
                player.playerState = new RightMovingPlayerState(player, health);
                break;
            case PlayerDirection.Up:
                player.playerState = new UpMovingPlayerState(player, health);
                break;
            case PlayerDirection.Down:
                player.playerState = new DownMovingPlayerState(player, health);
                break;

        }


    }

    public void DeathState()
    {
        playerState.State = new DeadPlayerState(playerState);
    }


    public void TakeDamage(int damageAmount)
    {

        //immunity for x amount of time
        //decrease global health by x amount
        //check if DeadPlayerState is needed

        health -= damageAmount;

        if (health <= 0)
        {
            playerState.State = new DeadPlayerState(playerState);

        }

    }
    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void UseWeapon()
    {
        //different sprite drawn
        //switch case depending on which direction facing
        //is a timed state, how to handle?
    }

    public void VictoryState()
    {
        playerState.State = new VictoryPlayerState(playerState);
    }
}