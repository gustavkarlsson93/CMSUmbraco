using System;
namespace FootballCMS.Model
{
    public class PlayerModel
    {
        public Task<string> fullName { get; set; }

        public PlayerModel(Task<string> fullName)
        {
            this.fullName = fullName;
        }
    }
}

