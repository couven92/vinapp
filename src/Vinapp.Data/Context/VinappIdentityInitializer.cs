﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Vinapp.Data.Models;

namespace Vinapp.Data.Context
{
    public class VinappIdentityInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<User> _userManager;

        public VinappIdentityInitializer(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            await CreateSuperUserRole();
            await CraeteAdminUserRole();
            await CraeteRegularUserRole();

            await CreateUsers();
        }

        private async Task CreateSuperUserRole()
        {
            var superUser = await _roleManager.RoleExistsAsync(Roles.SuperUser.ToString());
            if (!superUser)
            {
                var role = new IdentityRole(Roles.SuperUser.ToString());
                var claim = new IdentityRoleClaim<string> { ClaimType = "IsSuperUser", ClaimValue = "True" };

                role.Claims.Add(claim);
                await _roleManager.CreateAsync(role);
            }
        }

        private async Task CraeteAdminUserRole()
        {
            var adminUser = await _roleManager.RoleExistsAsync(Roles.AdminUser.ToString());
            if (!adminUser)
            {
                var role = new IdentityRole(Roles.AdminUser.ToString());
                var claim = new IdentityRoleClaim<string> { ClaimType = "IsAdminUser", ClaimValue = "True" };

                role.Claims.Add(claim);
                await _roleManager.CreateAsync(role);
            }
        }

        private async Task CraeteRegularUserRole()
        {
            var regularUser = await _roleManager.RoleExistsAsync(Roles.RegularUser.ToString());
            if (!regularUser)
            {
                var role = new IdentityRole(Roles.RegularUser.ToString());
                var claim = new IdentityRoleClaim<string> { ClaimType = "IsRegularUser", ClaimValue = "True" };

                role.Claims.Add(claim);
                await _roleManager.CreateAsync(role);
            }
        }

        private async Task CreateUsers()
        {
            var user = await _userManager.FindByEmailAsync("ivan.milanovic@ciber.no");
            if (user == null)
            {
                user = new User
                {
                    UserName = "Ivan",
                    FirstName = "Ivan",
                    LastName = "Milanovic",
                    Email = "ivan.milanovic@ciber.no"
                };
                await _userManager.CreateAsync(user, "P@ssw0rd!");
                await _userManager.AddToRoleAsync(user, Roles.SuperUser.ToString());
                await _userManager.AddClaimAsync(user, new Claim(Claims.SuperUser.ToString(), "True"));
                await _userManager.AddClaimAsync(user, new Claim(Claims.AdminUser.ToString(), "True"));
                await _userManager.AddClaimAsync(user, new Claim(Claims.RegularUser.ToString(), "True"));
            }

            user = await _userManager.FindByEmailAsync("njaal.gjerde@ciber.no");
            if (user == null)
            {
                user = new User
                {
                    UserName = "Njaal",
                    FirstName = "Njaal",
                    LastName = "Gjerde",
                    Email = "njaal.gjerde@ciber.no"
                };
                await _userManager.CreateAsync(user, "P@ssw0rd!");
                await _userManager.AddToRoleAsync(user, Roles.RegularUser.ToString());
                await _userManager.AddClaimAsync(user, new Claim(Claims.RegularUser.ToString(), "True"));
            }

            user = await _userManager.FindByEmailAsync("bente.schiefloe@ciber.no");
            if (user == null)
            {
                user = new User
                {
                    UserName = "Bente",
                    FirstName = "Bente",
                    LastName = "Schiefloe",
                    Email = "bente.schiefloe@ciber.no"
                };
                await _userManager.CreateAsync(user, "P@ssw0rd!");
                await _userManager.AddToRoleAsync(user, Roles.AdminUser.ToString());
                await _userManager.AddClaimAsync(user, new Claim(Claims.AdminUser.ToString(), "True"));
                await _userManager.AddClaimAsync(user, new Claim(Claims.RegularUser.ToString(), "True"));
            }
        }
    }
}
