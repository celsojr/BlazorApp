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

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<ThingTag> ThingTags { get; set; } = new List<ThingTag>();

        public string TagsString { get; private set; } = string.Empty;

        [NotMapped]
        public List<string> Tags
        {
            get => TagsString.Split([','], StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList();
            set => TagsString = string.Join(",", value);
        }

        public void AddTag(string tag)
        {
            if (!string.IsNullOrWhiteSpace(tag))
            {
                var trimmedTag = tag.Trim();
                if (!Tags.Contains(trimmedTag))
                {
                    var currentTags = Tags.ToList();
                    currentTags.Add(trimmedTag);
                    Tags = currentTags;

                    ThingTags.Add(new ThingTag { Tag = new Tag { Name = trimmedTag } });
                }
            }
        }

        public void RemoveTag(string tag)
        {
            if (Tags.Contains(tag))
            {
                var currentTags = Tags.ToList();
                currentTags.Remove(tag);
                Tags = currentTags;

                var thingTagToRemove = ThingTags.FirstOrDefault(tt => tt.Tag.Name == tag);
                if (thingTagToRemove != null)
                {
                    ThingTags.Remove(thingTagToRemove);
                }
            }
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Thing> Things { get; set; } = [];
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ThingTag> ThingTags { get; set; } = [];
    }

    public class ThingTag
    {
        public int ThingId { get; set; }
        public Thing Thing { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }

}
