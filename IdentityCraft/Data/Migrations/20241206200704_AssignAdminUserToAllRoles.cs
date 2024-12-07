using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityCraft.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminUserToAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId, RoleId) select '740e71d2-c29c-48bc-a0fc-e1dea02ec436' ,  Id from [security].[Roles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from  [security].[UserRoles] where UserId = '740e71d2-c29c-48bc-a0fc-e1dea02ec436'");
        }
    }
}
