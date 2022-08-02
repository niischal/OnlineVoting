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
                            ElectionType = ElectionType.CandidateChoosing,
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
                    context.SaveChanges();
                }
            }
        }
    }
}
