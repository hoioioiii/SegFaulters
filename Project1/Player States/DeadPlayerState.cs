public class DeadPlayerState : IPlayerState
{
    private PlayerState player;
    //placeholder till connected with global health system
    public DeadPlayerState(PlayerState player)
    {
        this.player = player;
        //construct sprite here too?? (texture?)
    }
    public void ChangeDirection()
    {
        // no-op
    }

    public void DeathState()
    {
        //draw a dead player sprite!
    }

    public void TakeDamage(int damageAmount)
    {
        // no-op
    }

    public void Update()
    {
        //not sure how to approach this
    }

    public void UseWeapon()
    {
        // no-op
    }

    public void VictoryState()
    {
        // no-op
    }
}