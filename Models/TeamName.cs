using System.ComponentModel.DataAnnotations;

namespace BasketballStore.Models
{
    public class TeamName
    {
        public int TeamNameId { get; set; }

        [Required]
        [ValidNbaTeam(ErrorMessage = "Please enter a valid NBA team name.")]
        public string Name { get; set; }
    }
}
