using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace user.infrastructure.migrations
{
    [Migration(202209230001)]
    public class initial_tables_202209230001 : Migration
    {
        public override void Down()
        {
            Delete.Table("users");
            Delete.Table("wallets");
        }

        public override void Up()
        {          
            Create.Table("wallets")
            .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("created_by").AsString(50).NotNullable()
            .WithColumn("created").AsDateTime().NotNullable()
            .WithColumn("modified_by").AsString(50).Nullable()
            .WithColumn("modifed").AsDateTime().Nullable()
            .WithColumn("card_name").AsString(50).NotNullable()
            .WithColumn("card_number").AsString(50).NotNullable()
            .WithColumn("cvv").AsString(50).NotNullable()
            .WithColumn("expiration").AsString(50).NotNullable();

            Create.Table("users")
            .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("created_by").AsString(50).NotNullable()
            .WithColumn("created").AsDateTime().NotNullable()
            .WithColumn("modified_by").AsString(50).Nullable()
            .WithColumn("modifed").AsDateTime().Nullable()
            .WithColumn("username").AsString(50).NotNullable()
            .WithColumn("password").AsString(50).NotNullable()
            .WithColumn("first_name").AsString(50).NotNullable()
            .WithColumn("last_name").AsString(50).NotNullable()
            .WithColumn("country").AsString(50).NotNullable()
            .WithColumn("zip_code").AsString(50).NotNullable()
            .WithColumn("wallet_id").AsInt32().NotNullable().ForeignKey("wallets","id");
        }
    }
}
