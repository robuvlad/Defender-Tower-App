﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IEnemy
    {
        float Health { get; set; }
        float Speed { get; set; }
    }
}
