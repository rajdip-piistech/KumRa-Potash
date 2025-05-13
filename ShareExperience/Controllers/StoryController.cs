using System.Text.RegularExpressions;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareExperience.Data;
using ShareExperience.Models;

namespace ShareExperience.Controllers;

public class StoryController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;

    public IActionResult List(string search, int page = 1)
    {
        int pageSize = 6;
        var filtered = _context.Stories
            .Where(s => string.IsNullOrEmpty(search) || s.Title.Contains(search))
            .ToList();

        ViewBag.TotalPages = (int)Math.Ceiling(filtered.Count / (double)pageSize);
        ViewBag.Page = page;
        ViewBag.Search = search;

        var pagedStories = filtered.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return View(pagedStories);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Story story)
    {
        if (!ModelState.IsValid) return View(story);
        _context.Stories.Add(story);
        _context.SaveChanges();
        return RedirectToAction("List");
    }
    public IActionResult Details(int id)
    {
        var story = _context.Stories.Include(s => s.Comments).FirstOrDefault(s => s.Id == id);
        return View(story);
    }

    [HttpPost]
    public IActionResult Comment(int storyId, string name, string message)
    {
        var comment = new Comment { StoryId = storyId, Name = name, Message = message };
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return RedirectToAction("Details", new { id = storyId });
    }
}