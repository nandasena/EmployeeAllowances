#Install Ef to PC

    dotnet tool install --global dotnet-ef --version 7.0.15   
 

#create Ef  Migration file Initialies 

    dotnet ef migrations add InitialCreate --project ../EmployeeAllowance.Intrastructure

#Ef update the SQL

    dotnet ef database update

 #Ef add Storad Procedure
 
    Add-migration ManageEmployeeAllowancesData


#TODO

Need to add authentication layer.

Filed upload Part shoud be work in backgroud  proccess.
