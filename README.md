# ShoppingCart

 //IEnumerable && IQueryable

 //IEnumerable : Array, List, Dictionary
 //if we already have a list of record
 //it doesn't apply where condition at database level so not suitable for db query

 //IQueryable : It should be used DB queries or remote query
 //it filter or uses where condition at the database level itself

 //Three different lifetimes of dependency in ASP .Net core mvc/not mvc./api --only available in .Net Core
 //DI is inbuilt in case of .net core
 //Autofac, dot net framework 4.8, castle windsor, ninject, unity

 //AddSingleton -- logger
 //AddTransient --- Payment system -- slowness - overcome ith help of infrastructure
 //AddScoped -- dbcontext