namespace HotelReservarion_PL.Extensions
{
    public static class UserManagerExtenion
    {
        public static async Task<ApplicationUser> FindUserWithAddressByEmail(this UserManager<ApplicationUser> userManager, ClaimsPrincipal User)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users.Include(x => x.Email).FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
