using _02_SqlStorage_Recap.Managers;

UserManager userManager = new UserManager();
ProductManager productManager = new ProductManager();

userManager.CreateUser("Hans", "Mattin-Lassei", "hans@domain.com", "Nordkapsvägen 1", "13657", "Vega");

productManager.CreateProduct("Product 2", "This is a description", 200, "Belysning");