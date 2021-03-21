using ComplaintForm.Entities;
using System.Data.Entity;


namespace ComplaintForm.DataModel
{
    public class EntitiesModel : DbContext
    {
        public EntitiesModel()
        : base("Server=DESKTOP-99TSLD9\\SQLEXPRESS;Database=ComplaintForm;Trusted_Connection=True;MultipleActiveResultSets=True;")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserForms> UserForms { get; set; }
        public virtual DbSet<Complaints> Complaints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("COMPLAINTS");

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserForms)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserForms>()
              .HasMany(e => e.Complaints)
              .WithRequired(e => e.UserForm)
              .HasForeignKey(e => e.FormId)
              .WillCascadeOnDelete(false);
        }
    }
}
