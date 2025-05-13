using System.Xml.Linq;

namespace ShareExperience.Models;

public class Story
{
    public int Id { get; set; }
    public string Vibe { get; set; } // Good / Bad

    //public string Company { get; set; }
    //public string Designation { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;
    public List<Comment> Comments { get; set; } = new List<Comment>();
}