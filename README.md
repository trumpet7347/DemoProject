# To Run
1. Download the project, either by downloading the zip file, or cloning the repository
2. Open a command prompt in the API folder
3. run the following commands, this will get the API up and running
   1.  ```dotnet retore```
   2. ```cd .\API\```
   3. ```dotnet run```
4. Open a web brower and go to the following link, you should see a message saying "Test Data Setup", this will initialize the in memeory data store with all the needed data
   1. https://localhost:5001/api/setup
5. Open a new command prompt in the UI folder
6. Run the following commands, it will get the UI up and running
   1. ```npm install```
   2. ```ng serve```
7. Open a web browser and go to the following link to view the UI
   1. http://localhost:4200/