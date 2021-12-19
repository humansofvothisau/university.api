# HOV University API
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white "C#")](https://docs.microsoft.com/vi-vn/dotnet/csharp/ "C#") [![.NET 5](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white ".NET 5")](https://dotnet.microsoft.com/en-us/ ".NET 5")

This project is developed on behalf of [Humans Of Vo Thi Sau](https://www.facebook.com/HumansVTS "Humans Of Vo Thi Sau"). Our aim is to create a website that provide the students information about the National High School Graduation Exam. You can find the web app repository [here](https://github.com/humansofvothisau/university.webapp "HOV University") or see the latest version of website [here](https://university.humansofvothisau.com/ "here").

This API project is built on [C#](https://docs.microsoft.com/vi-vn/dotnet/csharp/ "C#") with [.NET 5](https://dotnet.microsoft.com/en-us/ ".NET 5") with Repository and Singleton Design Pattern for Data Access and 3-Layer Architecture with Presentation Layer (the API Web App), Business Layer (Business Object), Data Layer (Object for Data Access).

The API crawls the data from [https://diemthi.tuyensinh247.com/diem-chuan.html](https://diemthi.tuyensinh247.com/diem-chuan.html "https://diemthi.tuyensinh247.com/diem-chuan.html").
## Current Features
See the latest release version and more details in release notes at Release page. With the current release, the API supports:

- Getting the list of universities and colleges in Vietnam.
- Search for the benchmark for more than 500 universities and colleges in Vietnam.
- Look up the exam mark based on their exam identification number (for the current year only).

## Planned Features
In the future release, we are planned to improve the website and API to be available for:
- Using our own database instead of retrieving directly from other websites.
- Searching the subjects that are in a subject block.
- Providing the students with a diverse database of exam review questions and tests.
- Providing a console / webpage for Admin.
- Improve the API performance and debugging.

## Clone the project
Because we do not use any database in this version of release, so you can clone and run the project easily with **.NET SDK** installed on your machine.
### Git Clone
`git clone https://github.com/humansofvothisau/university.api`
### Compile the solution
`dotnet build`
### Run the API
`dotnet run --project university.api `

Access to `https://localhost:5001/api/[endpoint]` on your browser to see the result.
## Contact
Feel free to contact us if there is any problem:
### Humans Of Vo Thi Sau
- Website: [humansofvothisau.com](https://humansofvothisau.com "humansofvothisau.com")
- Email: humansofvothisau@gmail.com
- Facebook: [https://www.facebook.com/HumansVTS](https://www.facebook.com/HumansVTS "https://www.facebook.com/HumansVTS")
### Tran Phong
Or you can contact to the developer of this project, Tran Phong
- Email: n.tranphongse@gmail.com
- Github: [https://github.com/ntrphongse](https://github.com/ntrphongse "https://github.com/ntrphongse")
- Facebook: [https://www.facebook.com/phongntse/](https://www.facebook.com/phongntse/ "https://www.facebook.com/phongntse/")
