﻿namespace ShareExperience.Models;

public class Comment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
    public int StoryId { get; set; }
}