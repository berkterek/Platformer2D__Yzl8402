using NUnit.Framework;
using Platformer2d.Abstracts.Combats;
using Platformer2d.Combats;
using NSubstitute;
using Platformer2d.Abstracts.Controllers;
using Platformer2d.Abstracts.DataContainers;

namespace Combats
{
    public class health_test
    {
        //TDD test driven development => test gudumlu proje gelistirme

        private IHealth GetHealth()
        {
            var player = Substitute.For<IPlayerController>();
            player.Stats.Returns(Substitute.For<IPlayerStats>());
            player.Stats.MaxHealth.Returns(100);
            return new Health(player.Stats);
        }

        private IAttacker GetAttacker(int damage)
        {
            var attacker = Substitute.For<IAttacker>();
            attacker.Damage.Returns(damage);
            return attacker;
        }

        [Test]
        public void take_damage_after_max_health_and_current_health_not_equal()
        {
            //Arrange
            var health = GetHealth();
            var attacker = GetAttacker(5);

            int maxHealth = health.MaxHealth;

            //Act
            health.TakeDamage(attacker);

            //Assert
            Assert.AreNotEqual(maxHealth, health.CurrentHealth);
        }

        [Test]
        public void on_dead_triggered_when_take_fatal_damage()
        {
            //Arrange
            var health = GetHealth();
            var attacker = GetAttacker(health.MaxHealth);

            //Act
            string result = string.Empty;

            health.OnDead += () => result = "On Dead Triggered";
            health.TakeDamage(attacker);

            //Assert
            Assert.AreNotEqual("", result);
        }

        [Test]
        public void on_dead_not_triggered_when_take_regular_damage()
        {
            //Arrange
            var health = GetHealth();
            var attacker = GetAttacker(5);

            //Act
            string result = string.Empty;

            health.OnDead += () => result = "On Dead Triggered";
            health.TakeDamage(attacker);

            //Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void take_fatal_damage_current_health_not_less_then_zero()
        {
            //Arrange
            var health = GetHealth();
            var attacker = GetAttacker(health.MaxHealth + 5);

            //Act
            health.TakeDamage(attacker);

            //Assert
            Assert.GreaterOrEqual(health.CurrentHealth,0);
        }
    }
}