using System.Runtime.CompilerServices;

namespace MinimalAPIDemo
{
    public static class API
    {
        public static void ConfigureAPI(this WebApplication webApplication)
        {
            webApplication.MapGet("/Users", GetUsers);
            webApplication.MapGet("/Users/{id}", GetUser);
            webApplication.MapPost("/Users", InsertUser);
            webApplication.MapPut("/Users", UpdateUser);
            webApplication.MapDelete("/Users", Delete);
        }

        private static async Task<IResult> GetUsers(IUserDataRepo data)
        {
            try
            {
                return Results.Ok(await data.GetUser());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUser(int id, IUserDataRepo data)
        {
            try
            {
                var userData = await data.GetUser((id));
                if (userData == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(userData);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertUser(UserModel user, IUserDataRepo data)
        {
            try
            {
                await data.InsertUser(user);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        private static async Task<IResult> UpdateUser(UserModel user, IUserDataRepo data)
        {
            try
            {
                await data.UpdateUser(user);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        private static async Task<IResult> Delete(int id, IUserDataRepo data)
        {
            try
            {
                await data.DeleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }


    }
}
