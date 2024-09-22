using System.ComponentModel.DataAnnotations;

namespace BondGadgetCollection.Models
{
    public class GadgetModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Movie Title")]
        public string Name { get; set; }
        [Required]
        [Display(Description = "Movie Discription")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Appears In")]
        public string AppearsIn { get; set; }
        [Required]
        [Display(Name ="With this actor")]
        public string WithThisActor { get; set; }

        public GadgetModel()
        {
            Id = -1;
            Name = "Nothing";
            Description = "Nothing yet";
            AppearsIn = "Nowhere";
            WithThisActor = "with no one";
        }

        public GadgetModel(int id, string name, string description, string appearsIn, string withThisActor)
        {
            Id = id;
            Name = name;
            Description = description;
            AppearsIn = appearsIn;
            WithThisActor = withThisActor;
        }
    }
}
