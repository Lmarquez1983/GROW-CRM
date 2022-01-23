using GROW_CRM.Models;
using GROW_CRM.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GROW_CRM.Data
{
    public class GROWContext : DbContext
    {
        public GROWContext(DbContextOptions<GROWContext> options) : base(options)
        {
            UserName = "SeedData";
        }

        //To give access to IHttpContextAccessor for Audit Data with IAuditable
        private readonly IHttpContextAccessor _httpContextAccessor;

        //Property to hold the UserName value
        public string UserName
        {
            get; private set;
        }

        public GROWContext(DbContextOptions<GROWContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            UserName = _httpContextAccessor.HttpContext?.User.Identity.Name;
            UserName = UserName ?? "Unknown";
        }

        //Datasets
        public DbSet<DietaryRestriction> DietaryRestrictions { get; set; }

        public DbSet<DietaryRestrictionMember> DietaryRestrictionMembers { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Household> Households { get; set; }

        public DbSet<HouseholdDocument> HouseholdDocuments { get; set; }

        public DbSet<HouseholdNotification> HouseholdNotifications { get; set; }

        public DbSet<IncomeSituation> IncomeSituations { get; set; }

        public DbSet<Item> Items { get; set; }        

        public DbSet<Member> Members { get; set; }        

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<NotificationType> NotificationTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<Province> Provinces { get; set; }

        //Methods

        //Model Builder Event
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("GROW");

            //Adding Composite Keys
            modelBuilder.Entity<DietaryRestrictionMember>()
                .HasKey(dm => new { dm.MemberID, dm.DietaryRestrictionID });

            modelBuilder.Entity<HouseholdNotification>()
                .HasKey(hn => new { hn.HouseholdID, hn.NotificationID });

            //Cascading Delete Restriction
            
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;

                        case EntityState.Added:
                            trackable.CreatedOn = now;
                            trackable.CreatedBy = UserName;
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;
                    }
                }
            }
        }
    }
}