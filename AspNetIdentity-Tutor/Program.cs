using System.Security.Claims;
using CookieOptions = AspNetIdentity_Tutor.Options.CookieOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieOptions.AuthCookieName)
    .AddCookie(CookieOptions.AuthCookieName, config =>
    {
        config.Cookie.Name = CookieOptions.AuthCookieName;
    });
builder.Services.AddAuthorization(ops =>
{
    ops.AddPolicy("AdminOnly",
        policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();