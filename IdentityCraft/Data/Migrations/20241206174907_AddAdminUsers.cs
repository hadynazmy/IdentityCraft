using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityCraft.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [security].[Users] 
        ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], 
        [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], 
        [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePicture]) 
    VALUES 
        (N'd5b6a62b-30f8-4cda-8d88-cbbc374bb701', N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, 
        N'AQAAAAIAAYagAAAAEPD5v7L+NMmgSBrcFDcKYuDf1ZwQqu5ocoDC7Bt1ZrYgwr/ylKsZdhPEei1KLFb98w==', 
        N'WHFUCMXDUGD7OMW77DFXVXBZKMFYH5RZ', N'2cbb7926-84b1-4867-b56d-150c6ee01324', N'01111170300', 0, 0, NULL, 1, 
        0, N'hady', N'nazmy', 0x00);");
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id= 'd5b6a62b-30f8-4cda-8d88-cbbc374bb701'");
        }
    }
}
