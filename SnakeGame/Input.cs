﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    class Input
    {
        private static Hashtable keys = new Hashtable();

        public static void ChangeState(Keys key, bool state)
        {
            keys[key] = state;
        }

        public static bool Pressed(Keys key)
        {
            if (keys[key] == null)
                return false;
            return (bool)keys[key];
        }
    }
}
