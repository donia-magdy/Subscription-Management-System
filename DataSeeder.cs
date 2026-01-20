using SubscriptionManagementSystem.Domain;
using SubscriptionManagementSystem.Domain_Shared;
using SubscriptionManagementSystem.EntityFrameworkCore;

namespace SubscriptionManagementSystem
{
    public static class DataSeeder
    {
        public static void SeedInitialData(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            // Users
            //if (!context.Users.Any())
            //{

            //    var users = new List<User>
            //{
            //    new User
            //    {
            //        Name = "user1",
            //        Email = "user1@gmail.com"
            //    },
            //    new User
            //    {
            //        Name = "user2",
            //        Email = "user2@gmail.com"
            //    },
            //    new User
            //    {
            //        Name = "user3",
            //        Email = "user3@gmail.com"
            //    }
            //};
            //    context.Users.AddRange(users);
            //    context.SaveChanges();
            //}

            // Subscriptions   
            if (!context.Subscriptions.Any())
            {
                var subscriptions = new List<Subscription>
            {
                    new Subscription
                {
                    Name = "Bundle1",
                    Price = 4.99m,
                    Cycle = Cycle.Weekly,
                    IsActive = true
                },
                new Subscription
                {
                    Name = "Bundle2",
                    Price = 9.99m,
                    Cycle = Cycle.Monthly,
                    IsActive = true
                },
                new Subscription
                {
                    Name = "Bundle3",
                    Price = 19.99m,
                    Cycle = Cycle.Quarter,
                    IsActive = true
                }
                
            };
            context.Subscriptions.AddRange(subscriptions);
            context.SaveChanges();
            }
            // UserSubscriptions
            //if (!context.UserSubscriptions.Any())
            //{
            //    var userSubscriptions = new List<UserSubscription>
            //{
            //    new UserSubscription
            //    {
            //        UserId = 1,
            //        SubscriptionId = 1,
            //        StartDate = DateTime.Now,
            //        EndDate = DateTime.Now.AddDays(7)
            //    },
            //    new UserSubscription
            //    {
            //        UserId = 2,
            //        SubscriptionId = 2,
            //        StartDate = DateTime.Now,
            //        EndDate = DateTime.Now.AddMonths(1)
            //    },
            //    new UserSubscription
            //    {
            //        UserId = 3,
            //        SubscriptionId = 3,
            //        StartDate = DateTime.Now,
            //        EndDate = DateTime.Now.AddMonths(4)
            //    }

            //};
            //context.UserSubscriptions.AddRange(userSubscriptions);
            //context.SaveChanges();
            //}
            // Payments
            //if (!context.Payments.Any())
            //{
            //    var payments = new List<Payment>
            //    {
            //        new Payment
            //        {
            //            UserSubscriptionId = 1,
            //            Amount = 4.99m,
            //            PaidAt = DateTime.Now,
            //            PaymentMethod = PaymentMethod.Cash
            //        },
            //        new Payment
            //        {
            //            UserSubscriptionId = 2,
            //            Amount = 9.99m,
            //            PaidAt = DateTime.Now,
            //            PaymentMethod = PaymentMethod.Visa
            //        },
            //        new Payment
            //        {
            //            UserSubscriptionId = 3,
            //            Amount = 19.99m,
            //            PaidAt = DateTime.Now,
            //            PaymentMethod = PaymentMethod.Cash
            //        }
            //    }; context.Payments.AddRange(payments);
            //    context.SaveChanges();
            //}
            // Lookup Types
            if (!context.LookupTypes.Any())
            {
                var lookupTypes = new List<LookupType>
            {
                new LookupType { Code = "CYCLE", Name = "Subscription Cycle" },
                new LookupType { Code = "PAYMENT", Name = "Payment Method" }
            };

                context.LookupTypes.AddRange(lookupTypes);
                context.SaveChanges();
            }
            // Lookup Values
            if (!context.LookupValues.Any()) 
            {
                var cycleType = context.LookupTypes.FirstOrDefault(lt => lt.Code == "CYCLE");
                var paymentType = context.LookupTypes.FirstOrDefault(lt => lt.Code == "PAYMENT");
                if (cycleType == null || paymentType == null)
                {
                    Console.WriteLine("CycleType or PaymentType not found!");
                    return;
                }
                var lookupValues = new List<LookupValue>
                {
                    new LookupValue { Code = "WEEKLY", Name = "Weekly", LookupTypeId = cycleType.Id },
                    new LookupValue {Code = "MONTHLY", Name = "Monthly", LookupTypeId = cycleType.Id },
                    new LookupValue {Code = "QUARTER", Name = "Quarter", LookupTypeId = cycleType.Id },
                    new LookupValue {Code = "BI_ANNUAL", Name = "Bi-Annual", LookupTypeId = cycleType.Id },
                    new LookupValue {Code = "ANNUAL", Name = "Annual", LookupTypeId = cycleType.Id },
                    new LookupValue { Code = "VISA", Name = "Visa", LookupTypeId = paymentType.Id },
                    new LookupValue {Code = "CASH", Name = "Cash", LookupTypeId = paymentType.Id }
                };
                context.LookupValues.AddRange(lookupValues);
                Console.WriteLine($"LookupValues count: {context.LookupValues.Count()}");

                context.SaveChanges();
            }
        }
    }
}
