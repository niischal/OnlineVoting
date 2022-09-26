using Microsoft.AspNetCore.Identity;
using OnlineVoting.Data.Static;
using OnlineVoting.Models;

namespace OnlineVoting.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Seeding Data to tables

                //Elections
                if (!context.Elections.Any())
                {
                    context.Elections.AddRange(new List<Election>()
                    {
                        new Election()
                        {
                            //ElectionId = 1,
                            ElectionName = "Board Members",
                            StartDate = DateTime.Now.AddDays(10),
                            EndDate = DateTime.Now.AddDays(11),
                            Decription = "Vote for Your Favourite Candidate for Board Members",
                            ElectionType = ElectionType.CandidateChoosing,
                            ElectionState = ElectionState.NotStarted
                        },
                        new Election()
                        {
                           // ElectionId=2,
                            ElectionName = "Policy Choose",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            Decription = "Vote for Your Policy",
                            ElectionType = ElectionType.PolicyMaking,
                            ElectionState = ElectionState.NotStarted
                        },
                        new Election()
                        {
                           // ElectionId =3,
                            ElectionName = "School Captains",
                            StartDate = DateTime.Now.AddDays(31),
                            EndDate = DateTime.Now.AddDays(32),
                            Decription = "Vote for Your Favourite Candidate for School Coptains",
                            ElectionType = ElectionType.CandidateChoosing,
                            ElectionState = ElectionState.NotStarted
                        }
                    }) ;
                    context.SaveChanges();
                }
                //Position
                if (!context.Positions.Any())
                {
                    context.Positions.AddRange(new List<Position>()
                    {
                        new Position()
                        {
                            //PositionId = 1,
                            PositionTitle = "President",
                            Description = "President of Organization",
                            ElectionId=1
                        },
                        new Position()
                        {
                            //PositionId = 2,
                            PositionTitle = "Vice President",
                            Description = "Vice President of Organization",
                            ElectionId=1
                        },
                        new Position()
                        {
                            //PositionId = 3,
                            PositionTitle = "Captain",
                            Description = "School Captain",
                            ElectionId=3
                        },
                        new Position()
                        {
                            //PositionId = 4,
                            PositionTitle = "Vice Captain",
                            Description = "School Vice Captain",
                            ElectionId=3
                        }
                    });
                    context.SaveChanges();
                }

                //Candidate
                if (!context.Candidates.Any())
                {
                    context.Candidates.AddRange(new List<Candidate>()
                    {
                        new Candidate()
                        { 
                            //CandidateId = 1,
                            CandidateName = "Iron Man",
                            CandidateIcon = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            PositionId = 1
                        },
                        new Candidate()
                        {
                            //CandidateId = 1,
                            CandidateName = "Thanos",
                            CandidateIcon = "http://dotnethow.net/images/actors/actor-2.jpeg",
                            PositionId = 1
                        },
                        new Candidate()
                        {
                           // CandidateId = 1,
                            CandidateName = "Spider Man",
                            CandidateIcon = "http://dotnethow.net/images/actors/actor-5.jpeg",
                            PositionId = 2
                        },
                        new Candidate()
                        {
                            //CandidateId = 1,
                            CandidateName = "Green Goblin",
                            CandidateIcon = "http://dotnethow.net/images/actors/actor-5.jpeg",
                            PositionId = 2
                        },
                        new Candidate()
                        {
                           // CandidateId = 1,
                            CandidateName = "Captain America",
                            CandidateIcon = "http://dotnethow.net/images/actors/actor-3.jpeg",
                            PositionId = 3
                        },
                        new Candidate()
                        {
                            //CandidateId = 1,
                            CandidateName = "Captain Marvel",
                            CandidateIcon = "http://dotnethow.net/images/actors/actor-4.jpeg",
                            PositionId = 3
                        },
                        new Candidate()
                        {
                            //CandidateId = 1,
                            CandidateName = "Thor",
                            CandidateIcon = "http://dotnethow.net/images/actors/actor-5.jpeg",
                            PositionId = 4
                        },
                        new Candidate()
                        {
                            //CandidateId = 1,
                            CandidateName = "God Butcher",
                            CandidateIcon = "http://dotnethow.net/images/actors/actor-5.jpeg",
                            PositionId = 4
                        }
                    });
                    context.SaveChanges();
                }
                //Policy
                if (!context.Policies.Any())
                {
                    context.Policies.AddRange(new List<Policy>()
                    {
                        new Policy()
                        {
                            //PolicyID=1,
                            PolicyTitle ="Avegers Assemble",
                            PolicyDescription ="Vote Yes if you want the avengers to assemble.",
                            ElectionId=2
                        }
                    });
                    context.SaveChanges();
                }
                //Voter
                if (!context.Voters.Any())
                {
                    context.Voters.AddRange(new List<Voter>()
                    {
                        new Voter()
                        {
                           // VoterId=1,
                            Firstname = "Tony",
                            LastName = "Stark",
                            UniqueId = "A001",
                            ElectionId=1
                        },
                        new Voter()
                        {
                            //VoterId=2,
                            Firstname = "Steve",
                            LastName = "Rogers",
                            UniqueId = "A002",
                            ElectionId=1
                        },
                        new Voter()
                        {
                            //VoterId=3,
                            Firstname = "Peter",
                            LastName = "Parker",
                            UniqueId = "A003",
                            ElectionId=1
                        },
                        new Voter()
                        {
                            //VoterId=4,
                            Firstname = "Nick",
                            LastName = "Fury",
                            UniqueId = "A000",
                            ElectionId=2
                        },
                        new Voter()
                        {
                            //VoterId=5,
                            Firstname = "Bruce",
                            LastName = "Banner",
                            UniqueId = "A004",
                            ElectionId=2
                        },
                        new Voter()
                        {
                            //VoterId=6,
                            Firstname = "Val",
                            LastName = "Kyrie",
                            UniqueId = "A019",
                            ElectionId=1
                        },
                        new Voter()
                        {
                            //VoterId=7,
                            Firstname = "Heim",
                            LastName = "Dall",
                            UniqueId = "A020",
                            ElectionId=1
                        },
                    });
                }
                //UserElections
                if (!context.UserElections.Any())
                {
                    context.UserElections.AddRange(new List<UserElection>()
                    {
                        new UserElection()
                        {
                            UserId = "6c5c3f84-2266-4ef1-8700-b7db68cb8562",
                            ElectionId = 1
                        },
                        new UserElection()
                        {
                            UserId = "6c5c3f84-2266-4ef1-8700-b7db68cb8562",
                            ElectionId = 2
                        },
                        new UserElection()
                        {
                            UserId = "6c5c3f84-2266-4ef1-8700-b7db68cb8562",
                            ElectionId = 3
                        },
                        new UserElection()
                        {
                            UserId = "11fc501e-f4a9-4bcb-97d2-dd2b49bfdbd4",
                            ElectionId = 1
                        },
                        new UserElection()
                        {
                            UserId = "11fc501e-f4a9-4bcb-97d2-dd2b49bfdbd4",
                            ElectionId = 2
                        }
                    }) ;
                }
                context.SaveChanges();
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.Voter))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Voter));
                }


                //Users
                //Admin
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string AdminEmail = "admin@dotmat.com";
                var adminUser = await userManager.FindByEmailAsync(AdminEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        UserName = "admin",
                        Email = AdminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser,"Dotm@t123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                //Voter
                string VoterEmail = "TestVoter@dotmat.com";
                var voter = await userManager.FindByEmailAsync(VoterEmail);
                if (voter== null)
                {
                    var newVoter = new ApplicationUser()
                    {
                        FirstName = "Test",
                        LastName = "Voter",
                        UserName = "testVoter",
                        Email = VoterEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newVoter, "Dotm@t123");
                    await userManager.AddToRoleAsync(newVoter, UserRoles.Voter);
                }
            }
        }
    }
}
