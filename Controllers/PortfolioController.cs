using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Models;

namespace ModernPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Project> projects = new List<Project>
        {
            new Project
            {
                Id = 1,
                Title = "IT Management System",
                Description = "A web-based system designed to manage IT operations and services.",
                FullDescription = "This project provides a centralized platform for managing IT-related information, users, services, and operational activities.",
                ImageUrl = "/images/it-management.png",
                GithubUrl = "https://github.com/ChristopherPantaleon/IT_ELECTIVE_2_MIDTERM_EXAM",
                Technologies = "ASP.NET Core MVC, C#, HTML, CSS"
            },

            new Project
            {
                Id = 2,
                Title = "Student Management System",
                Description = "A system for managing student information and academic records.",
                FullDescription = "The Student Management System allows users to organize student information and manage academic-related records through a simple web interface.",
                ImageUrl = "/images/student-management.png",
                GithubUrl = "https://github.com/ChristopherPantaleon/IT_ELECTIVE_2_MIDTERM_EXAM",
                Technologies = "ASP.NET Core MVC, C#, SQL"
            },

            new Project
            {
                Id = 3,
                Title = "Vehicle Service Monitoring",
                Description = "A vehicle service monitoring system for tracking service jobs.",
                FullDescription = "This system allows users to monitor vehicle service jobs, customer information, service status, and release information.",
                ImageUrl = "/images/vehicle-service.png",
                GithubUrl = "https://github.com/ChristopherPantaleon/IT_ELECTIVE_2_MIDTERM_EXAM",
                Technologies = "ASP.NET Core MVC, C#, BCrypt"
            },

            new Project
            {
                Id = 4,
                Title = "Eyelottea Restobar POS",
                Description = "A POS and inventory management application.",
                FullDescription = "A VB.NET Windows Forms application created to manage transactions, orders, payments, and inventory for a restobar.",
                ImageUrl = "/images/eyelottea.png",
                GithubUrl = "https://github.com/ChristopherPantaleon/IT_ELECTIVE_2_MIDTERM_EXAM",
                Technologies = "VB.NET, Windows Forms, MySQL"
            }
        };

        private static List<Comment> comments = new List<Comment>();

        public IActionResult Index()
        {
            return View(projects);
        }

        public IActionResult Details(int id)
        {
            var project = projects.FirstOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            ViewBag.Comments = comments
                .Where(c => c.ProjectId == id)
                .ToList();

            return View(project);
        }

        [HttpPost]
        public IActionResult AddComment(int projectId, string name, string message)
        {
            if (!string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(message))
            {
                comments.Add(new Comment
                {
                    Id = comments.Count + 1,
                    ProjectId = projectId,
                    Name = name,
                    Message = message,
                    DatePosted = DateTime.Now
                });
            }

            return RedirectToAction("Details", new { id = projectId });
        }
    }
}