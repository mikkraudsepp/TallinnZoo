using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DAL.App.EF.Migrations
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(AppDbContext context, UserManager<AppUser> userManager)
        {
            context.Database.EnsureCreated();
        }
    }
}