namespace Oxide.Plugins
{
    public partial class MyPlugin
    {
        private void OnEntityTakeDamage(BaseCombatEntity entity, HitInfo info)
        {
            if (entity == null || info == null || info.Initiator == null)
                return;

            var victim = entity.ToPlayer();
            if (victim == null)
                return;

            var attacker = info.Initiator.ToPlayer();
            if (attacker == null)
                return;

            if(attacker == victim)
                return;

            var user = Instance.Users.Get(attacker.UserIDString);
            if (user == null)
                return;
            // Example logic: Increase score when dealing to another player damage
            user.AddScore(1);
            Instance.Puts($"User {user.Name} ({user.Id}) score increased to {user.Score} for dealing damage.");
        }
    }
}
