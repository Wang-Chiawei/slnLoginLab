using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var constr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={builder.Environment.ContentRootPath}App_Data\\dbEmp.mdf;Integrated Security=True;Trusted_Connection=True;";
builder.Services.AddMvc();
builder.Services.AddDbContext<prjLoginLab.Models.EmpDbContext>
    (option=> option.UseSqlServer(constr)
    );


var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(name:"default",pattern: "{Controller=Home}/{Action=Index}/{id?}" );

app.Run();
