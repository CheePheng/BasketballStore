using System;
using System.ComponentModel.DataAnnotations;

namespace BasketballStore.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        [ValidNbaTeam(ErrorMessage = "Please enter a valid NBA team name.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class ValidNbaTeamAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] validTeams = {
                "Atlanta Hawks", "Boston Celtics", "Brooklyn Nets", "Charlotte Hornets", "Chicago Bulls",
                "Cleveland Cavaliers", "Dallas Mavericks", "Denver Nuggets", "Detroit Pistons", "Golden State Warriors",
                "Houston Rockets", "Indiana Pacers", "LA Clippers", "Los Angeles Lakers", "Memphis Grizzlies",
                "Miami Heat", "Milwaukee Bucks", "Minnesota Timberwolves", "New Orleans Pelicans", "New York Knicks",
                "Oklahoma City Thunder", "Orlando Magic", "Philadelphia 76ers", "Phoenix Suns", "Portland Trail Blazers",
                "Sacramento Kings", "San Antonio Spurs", "Toronto Raptors", "Utah Jazz", "Washington Wizards"
            };

            if (value != null && Array.IndexOf(validTeams, value.ToString()) == -1)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
