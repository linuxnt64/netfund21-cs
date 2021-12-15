
using _03_Interfaces.Handlers;
using _03_Interfaces.Interfaces;

IUserManager userManager = new UserManager();

userManager.UpdateEmailAddress("hans@domain.com");