using Abp.IdentityServer4vNext;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MCV.Portal.Authorization.Delegation;
using MCV.Portal.Authorization.Roles;
using MCV.Portal.Authorization.Users;
using MCV.Portal.Chat;
using MCV.Portal.Editions;
using MCV.Portal.Friendships;
using MCV.Portal.MultiTenancy;
using MCV.Portal.MultiTenancy.Accounting;
using MCV.Portal.MultiTenancy.Payments;
using MCV.Portal.Storage;
using MCV.Portal.Person;
using MCV.Portal.ITService;
using MCV.Portal.Category;
using MCV.Portal.Location;
using MCV.Portal.SubCategory;
using MCV.Portal.Branches;
using MCV.Portal.Problem;
using MCV.Portal.Subjects;
using MCV.Portal.Channels;

namespace MCV.Portal.EntityFrameworkCore
{
    public class PortalDbContext : AbpZeroDbContext<Tenant, Role, User, PortalDbContext>, IAbpPersistedGrantDbContext
    {

        /* Define an IDbSet for each entity of the application */
        public virtual DbSet<Channel> AbpChannels { get; set; }
        public virtual DbSet<Subject> AbpSubject { get; set; }
        public virtual DbSet<Person.Person> Persons { get; set; }
        public virtual DbSet<Calls> Calls { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<LocationType> LocationType { get; set; }
        public virtual DbSet<Branche> Branches { get; set; }
        public virtual DbSet<CallProblem> CallProblems { get; set; }
        public virtual DbSet<CategoryService.CategoryServe> CategoriesService { get; set; }
        public virtual DbSet<SubCategoryType> SubCategoryType { get; set; }

        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual DbSet<Friendship> Friendships { get; set; }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }

        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public virtual DbSet<SubscriptionPaymentExtensionData> SubscriptionPaymentExtensionDatas { get; set; }

        public virtual DbSet<UserDelegation> UserDelegations { get; set; }

        public PortalDbContext(DbContextOptions<PortalDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Branche>().HasKey(p => new { p.Id });
            modelBuilder.Entity<CallProblem>().HasKey(p => new { p.Id });
            modelBuilder.Entity<CategoryService.CategoryServe>().HasKey(p => new { p.Id });

            modelBuilder.Entity<BinaryObject>(b =>
            {
                b.HasIndex(e => new { e.TenantId });
            });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { PaymentId = e.ExternalPaymentId, e.Gateway });
            });

            modelBuilder.Entity<SubscriptionPaymentExtensionData>(b =>
            {
                b.HasQueryFilter(m => !m.IsDeleted)
                    .HasIndex(e => new { e.SubscriptionPaymentId, e.Key, e.IsDeleted })
                    .IsUnique();
            });

            modelBuilder.Entity<UserDelegation>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.SourceUserId });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
            //modelBuilder.Ignore<Branches.Branches>();
        }
    }
}
