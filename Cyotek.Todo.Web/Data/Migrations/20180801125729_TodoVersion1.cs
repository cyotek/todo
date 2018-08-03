using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cyotek.Todo.Data.Migrations
{
  public partial class TodoVersion1 : Migration
  {
    #region Methods

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(name: "TodoItems");

      migrationBuilder.DropIndex(name: "UserNameIndex", table: "AspNetUsers");

      migrationBuilder.DropIndex(name: "RoleNameIndex", table: "AspNetRoles");

      migrationBuilder.CreateIndex(name: "UserNameIndex", table: "AspNetUsers", column: "NormalizedUserName", unique: true, filter: "[NormalizedUserName] IS NOT NULL");

      migrationBuilder.CreateIndex(name: "RoleNameIndex", table: "AspNetRoles", column: "NormalizedName", unique: true, filter: "[NormalizedName] IS NOT NULL");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropIndex(name: "UserNameIndex", table: "AspNetUsers");

      migrationBuilder.DropIndex(name: "RoleNameIndex", table: "AspNetRoles");

      migrationBuilder.CreateTable(name: "TodoItems", columns: table => new
                                                                        {
                                                                          Created = table.Column<DateTimeOffset>(nullable: false),
                                                                          DueAt = table.Column<DateTimeOffset>(nullable: true),
                                                                          Id = table.Column<Guid>(nullable: false),
                                                                          OwnerId = table.Column<string>(nullable: true),
                                                                          Title = table.Column<string>(nullable: true),
                                                                          IsComplete = table.Column<bool>(nullable: false)
                                                                        }, constraints: table => { table.PrimaryKey("PK_TodoItems", x => x.Id); });

      migrationBuilder.CreateIndex(name: "UserNameIndex", table: "AspNetUsers", column: "NormalizedUserName", unique: true);

      migrationBuilder.CreateIndex(name: "RoleNameIndex", table: "AspNetRoles", column: "NormalizedName", unique: true);
    }

    #endregion
  }
}
