#### Running & Debugging Acme.RemoteFlights.Api Locally ####
* Clone this repo: https://github.com/RKL84/demo.git 
* Acme.RemoteFlights.Api *<sup>(ASP.NET Core Web API)</sup>*
  * Restore *([Acme.RemoteFlights.Api.bacpac](https://github.com/RKL84/demo/blob/master/Acme.RemoteFlights.Database/sql))* Acme.RemoteFlights SQL Database
  * Install lastest .NET Core SDK **after** Visual Studio 2017 installed
  * Open Acme.RemoteFlights.sln Solution in Visual Studio 2017
  * Set Acme.RemoteFlights.Api as Startup Project for the Solution
  * Verify SQL connection string in [appsettings.json](https://github.com/RKL84/demo/blob/master/Acme.RemoteFlights.Api/appsettings.Development.json#L16) is correct, respective to local environment
  * F5 to launch Acme.RemoteFlights.Api in debug mode in Visual Studio


