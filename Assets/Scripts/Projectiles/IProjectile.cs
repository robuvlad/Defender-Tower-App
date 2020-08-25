using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Projectiles
{
    public interface IProjectile
    {
        float Speed { get; set; }
        float Damage { get; set; }
    }
}
