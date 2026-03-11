using Game.Weapons;

namespace Game.Items
{
	public class GameItemWeapon : GameItem
	{
		public const float DamageLimit = 300f;

		public Weapon Weapon;

		public static float maxDamage
		{
			get;
			private set;
		}

		public static float minAttackDelay
		{
			get;
			private set;
		}

		public override void Init()
		{
			base.Init();
			if (Weapon.Damage > maxDamage)
			{
				maxDamage = Weapon.Damage;
			}
			if (maxDamage > 300f)
			{
				maxDamage = 300f;
			}
			if (minAttackDelay == 0f)
			{
				minAttackDelay = Weapon.AttackDelay;
			}
			if (minAttackDelay != 0f && Weapon.AttackDelay < minAttackDelay)
			{
				minAttackDelay = Weapon.AttackDelay;
			}
		}

		public override bool SameParametrWithOther(object[] parametrs)
		{
			return Weapon == (Weapon)parametrs[0];
		}
	}
}
