using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Data
{
    public class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        // Relationships
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<ThingTag> ThingTags { get; set; } = [];

        public string TagsString { get; set; } = string.Empty;

        [NotMapped]
        public ICollection<string> Tags
        {
            get => TagsString.Split([','], StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList();
            set => TagsString = string.Join(",", value);
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Relationships
        public ICollection<Thing> Things { get; set; } = [];
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Relationships
        public ICollection<ThingTag> ThingTags { get; set; } = [];
    }

    // Join table for many-to-many relationship between Thing and Tag
    public class ThingTag
    {
        public int ThingId { get; set; }
        public Thing Thing { get; set; } = null!;

        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }

}
