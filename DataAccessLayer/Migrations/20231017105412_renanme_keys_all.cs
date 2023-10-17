using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class renanme_keys_all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WriterStatus",
                table: "Writers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "WriterPassword",
                table: "Writers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "WriterName",
                table: "Writers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "WriterMail",
                table: "Writers",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "WriterImage",
                table: "Writers",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "WriterAbout",
                table: "Writers",
                newName: "About");

            migrationBuilder.RenameColumn(
                name: "WriterID",
                table: "Writers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ContactUsername",
                table: "Contacts",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "ContactSubject",
                table: "Contacts",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "ContactStatus",
                table: "Contacts",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ContactMessage",
                table: "Contacts",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "ContactMail",
                table: "Contacts",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "ContactDate",
                table: "Contacts",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "Contacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Comments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CommentUsername",
                table: "Comments",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "CommentTitle",
                table: "Comments",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "Comments",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CommentContent",
                table: "Comments",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "CommentID",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryStatus",
                table: "Categories",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "Categories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BlogTitle",
                table: "Blogs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "BlogThumbnail",
                table: "Blogs",
                newName: "Thumbnail");

            migrationBuilder.RenameColumn(
                name: "BlogStatus",
                table: "Blogs",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "BlogImage",
                table: "Blogs",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "BlogDate",
                table: "Blogs",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "BlogContent",
                table: "Blogs",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "BlogID",
                table: "Blogs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AboutStatus",
                table: "Abouts",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "AboutMapLocation",
                table: "Abouts",
                newName: "MapLocation");

            migrationBuilder.RenameColumn(
                name: "AboutImage2",
                table: "Abouts",
                newName: "Image2");

            migrationBuilder.RenameColumn(
                name: "AboutImage1",
                table: "Abouts",
                newName: "Image1");

            migrationBuilder.RenameColumn(
                name: "AboutDetail2",
                table: "Abouts",
                newName: "Detail2");

            migrationBuilder.RenameColumn(
                name: "AboutDetail1",
                table: "Abouts",
                newName: "Detail1");

            migrationBuilder.RenameColumn(
                name: "AboutID",
                table: "Abouts",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Writers",
                newName: "WriterStatus");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Writers",
                newName: "WriterPassword");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Writers",
                newName: "WriterName");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Writers",
                newName: "WriterMail");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Writers",
                newName: "WriterImage");

            migrationBuilder.RenameColumn(
                name: "About",
                table: "Writers",
                newName: "WriterAbout");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Writers",
                newName: "WriterID");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Contacts",
                newName: "ContactUsername");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Contacts",
                newName: "ContactSubject");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Contacts",
                newName: "ContactStatus");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Contacts",
                newName: "ContactMessage");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Contacts",
                newName: "ContactMail");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Contacts",
                newName: "ContactDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "ContactID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Comments",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Comments",
                newName: "CommentUsername");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Comments",
                newName: "CommentTitle");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comments",
                newName: "CommentDate");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "CommentContent");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Categories",
                newName: "CategoryStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "CategoryDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Blogs",
                newName: "BlogTitle");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "Blogs",
                newName: "BlogThumbnail");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Blogs",
                newName: "BlogStatus");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Blogs",
                newName: "BlogImage");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Blogs",
                newName: "BlogDate");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Blogs",
                newName: "BlogContent");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Blogs",
                newName: "BlogID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Abouts",
                newName: "AboutStatus");

            migrationBuilder.RenameColumn(
                name: "MapLocation",
                table: "Abouts",
                newName: "AboutMapLocation");

            migrationBuilder.RenameColumn(
                name: "Image2",
                table: "Abouts",
                newName: "AboutImage2");

            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "Abouts",
                newName: "AboutImage1");

            migrationBuilder.RenameColumn(
                name: "Detail2",
                table: "Abouts",
                newName: "AboutDetail2");

            migrationBuilder.RenameColumn(
                name: "Detail1",
                table: "Abouts",
                newName: "AboutDetail1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Abouts",
                newName: "AboutID");
        }
    }
}
