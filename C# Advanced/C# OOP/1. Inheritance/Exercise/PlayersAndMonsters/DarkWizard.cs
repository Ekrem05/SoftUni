using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class DarkWizard : Wizard
    {
        public DarkWizard(string username, int level) : base(username, level)
        {
            this.Username = username;
            this.Level = level;
        }
        public override string Username { get; set; }
        public override int Level { get; set; }
    }
}
