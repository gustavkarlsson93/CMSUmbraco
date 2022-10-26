using System;
namespace FootballCMS.Model
{
    public class PlayerModel
    {
        public string fullName { get; set; }

        public PlayerModel(string fullName)
        {
            this.fullName = fullName;
        }
    }
}

